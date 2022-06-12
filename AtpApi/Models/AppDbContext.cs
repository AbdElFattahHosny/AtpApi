using Microsoft.EntityFrameworkCore;

namespace AtpApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

    }
}
