using CaseVeiculo.Domain.Model.entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CaseVeiculo.Data.Data.db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<AuditoriaVeiculo> AuditoriaDoVeiculo { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
