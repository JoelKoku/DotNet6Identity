using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNet6Identity.Models.Domains
{
    public class DatabaseContext:IdentityDbContext<ApplicationUser>

    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) { 
        
        }
    }
}
