using System.ComponentModel.DataAnnotations;

namespace DotNet6Identity.Models.DTO
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
