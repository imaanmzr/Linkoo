using System.ComponentModel.DataAnnotations;

namespace Linkoo.Application.Common.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string UserName { get; set; }
        
        [Required]
        [MinLength(8)]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,30}$",ErrorMessage ="Password you've entered is weak")]
        public string Password { get; set; }
    }
}