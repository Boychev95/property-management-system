using Microsoft.AspNetCore.Identity;

namespace PropertyManagementSystem.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}