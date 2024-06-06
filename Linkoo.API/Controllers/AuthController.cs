using System.Security.Claims;
using Linkoo.Application.Common.Models.Identity;
using Linkoo.Application.Contracts.Identity.Services;
using Linkoo.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Linkoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IAuthService authService,
                              UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authService.Register(request));
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<AuthResponse>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            var currentUser = new AuthResponse{
                FirstName = user.FirstName,
                LastName = user.LastName,
                DisplayName = user.DisplayName,
                UserName = user.UserName,
                Email = user.Email,
            };
            return currentUser;
        }


    }
}