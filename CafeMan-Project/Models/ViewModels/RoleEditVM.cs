using CafeMan_Project.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace CafeMan_Project.Models.ViewModels
{
    public class RoleEditVM
    {
        public string Id { get; set; }
        public User CurentUser { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public List<string> UserRoles { get; set; }
        public List<string> Roles { get; set; }

    }
}
