using Microsoft.AspNetCore.Identity;
namespace DotNet6Identity.Models.Domains
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string ? ProfilePicture { get; set; }
    }
}
