using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Linkoo.Application.Common.Models.Identity;
using Linkoo.Application.Common.Models.Result;
using Linkoo.Application.Contracts.Identity.Services;
using Linkoo.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Linkoo.Identity.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHttpContextFactory _httpContextFactory;
    private readonly JwtSettings _jwtSettings;


    public AuthService(UserManager<ApplicationUser> userManager,
                       SignInManager<ApplicationUser> signInManager,
                       RoleManager<IdentityRole> roleManager,
                       IOptions<JwtSettings> jwtSettings,
                       IHttpContextFactory httpContextFactory)

    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _httpContextFactory = httpContextFactory;

        _jwtSettings = jwtSettings.Value;
    }
    public async Task<Result<AuthResponse>> Login(AuthRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return Result<AuthResponse>.Failure($"User with {request.Email} is not found");

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (result.Succeeded == false)
            return Result<AuthResponse>.Failure($"Credentials for {request.Email} are not valid");

        JwtSecurityToken jwtSecurityToken = await GenerateTokenAsync(user);

        var response = new AuthResponse
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email!,
            UserName = user.UserName!,
            DisplayName = user.DisplayName!,
            Image = null!
        };

        return Result<AuthResponse>.Success(response);
    }

    public async Task<Result<RegistrationResponse>> Register(RegistrationRequest request)
    {
        if (await _userManager.Users.AnyAsync(x => x.UserName == request.UserName))
        {
            return Result<RegistrationResponse>.Failure("Username is already taken");
        }

        if (await _userManager.Users.AnyAsync(x => x.Email == request.Email))
        {
            return Result<RegistrationResponse>.Failure("Email is already taken");
        }

        var user = new ApplicationUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DisplayName = request.DisplayName,
            Email = request.Email,
            UserName = request.UserName,
            EmailConfirmed = true,

        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            var roleExist = await _roleManager.RoleExistsAsync("User");
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
                return Result<RegistrationResponse>.Failure("Role 'User' created");
            }
            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (!roleResult.Succeeded)
            {
                StringBuilder str = new StringBuilder();
                foreach (var error in roleResult.Errors)
                {
                    str.AppendFormat("•{0}\n", error.Description);
                }
                return Result<RegistrationResponse>.Failure($"Failed to add user to role: {str}");
            }
            var registrationResponse = new RegistrationResponse() { UserName = user.UserName };
            return Result<RegistrationResponse>.Success(registrationResponse);
        }
        else
        {
            StringBuilder str = new StringBuilder();
            foreach (var error in result.Errors)
            {
                str.AppendFormat("•{0}\n", error.Description);
            }
            return Result<RegistrationResponse>.Failure($"{str}");
        }
    }

    public async Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim("uid", user.Id)
        }
         .Union(userClaims)
         .Union(roleClaims);

        var symmettricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var signingCredentials = new SigningCredentials(symmettricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
            );

        return jwtSecurityToken;
    }
}
