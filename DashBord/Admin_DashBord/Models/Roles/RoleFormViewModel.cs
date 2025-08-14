using System.ComponentModel.DataAnnotations;

namespace Admin_DashBord.Models.Roles
{
    public class RoleFormViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(256)]
        public string Name { get; set; } = null!;
    }
}
