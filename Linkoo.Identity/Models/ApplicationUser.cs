using Microsoft.AspNetCore.Identity;

namespace Linkoo.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? DisplayName { get; set; }
    public string? Bio { get; set; } = string.Empty;

}
