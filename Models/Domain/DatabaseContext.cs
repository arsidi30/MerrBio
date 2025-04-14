
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmIt.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<RecepiesCategory> RecepiesCategory { get; set; }
        public DbSet<Recepies> Recepies { get; set; }
       




    }
}
