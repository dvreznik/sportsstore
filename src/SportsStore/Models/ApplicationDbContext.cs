using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    // gateway between app and EF Core
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
