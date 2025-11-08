using GreenHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenHouse.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>()
                .HasKey(p => p.PlantName)
                .HasName("PK_PLANTS");

            modelBuilder.Entity<Plant>()
                .Property(p => p.SensorEvent)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}