using CaseVeiculo.Domain.Model.entities;
using Microsoft.EntityFrameworkCore;

namespace CaseVeiculo.Data.Data.db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> op) : base(op)
        {
        }
    }
}
