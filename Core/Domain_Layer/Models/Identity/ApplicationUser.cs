using Microsoft.AspNetCore.Identity;

namespace Domain_Layer.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; } = null!;
        public Address? Address { get; set; }
    }
}
