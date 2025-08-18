using GreenHouse.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GreenHouse.Data
{
    public class AppDbContext : DbContext
    {
        //  Essa propriedade representa a TABELA no banco
        public DbSet<Plant> Plants { get; set; }

        //  Construtor que recebe as opções (como connection string)
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //  Configurações adicionais (se necessário)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define chave primária personalizada e tipo de coluna
            modelBuilder.Entity<Plant>()
                .HasKey(p => p.PlantName)
                .HasName("PK_PLANTS");

            modelBuilder.Entity<Plant>()
                .Property(p => p.SensorEvent)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
