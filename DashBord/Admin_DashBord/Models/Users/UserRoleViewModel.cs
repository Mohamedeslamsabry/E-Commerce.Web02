using Admin_DashBord.Models.Roles;

namespace Admin_DashBord.Models.Users
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public List<RoleEditViewModel> Roles { get; set; } = [];
    }
}
