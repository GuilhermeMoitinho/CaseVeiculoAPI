using CaseVeiculo.Domain.Model.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseVeiculo.Data.Data.db.configurations
{
    public class VeiculoConfiguracao : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(v => v.MarcaDoVeiculo).IsRequired();
            builder.Property(v => v.Estado).IsRequired();
            builder.HasOne(v => v.AuditoriaDoVeiculo)
                .WithOne(a => a.Veiculo)
                .HasForeignKey<AuditoriaVeiculo>(a => a.VeiculoId);
        }
    }
}
