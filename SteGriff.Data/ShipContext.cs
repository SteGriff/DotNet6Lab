using Microsoft.EntityFrameworkCore;

namespace SteGriff.Data
{
    public record Ship(string Name, string Code, bool Deployed);

    public class ShipContext : DbContext
    {
        public ShipContext(DbContextOptions<ShipContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ship>().HasKey(s => s.Code);
        }

        public DbSet<Ship> Ships { get; set; }
    }
}
