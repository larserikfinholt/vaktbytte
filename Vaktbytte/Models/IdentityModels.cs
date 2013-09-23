using Microsoft.AspNet.Identity.EntityFramework;

namespace Vaktbytte.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {  
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public System.Data.Entity.DbSet<Vaktbytte.Models.Change> Change { get; set; }
    }
}