using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Identity
{
    public class RegisterDTO
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? UserName { get; set; } 
        public string DisplayName { get; set; } = null!;
        [Phone]
        public string? PhoneNumber  { get; set; } 
    }
}
