using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;

namespace CaseVeiculo.Domain.Model.interfaces
{
    public interface IAuditoriaRepository
    {
        Task AdicionarEstadosDoVeiculo(Guid Id, EstadosDoVeiculo estado);
        Task CriarHistoricoDeEstados(Guid Id, EstadosDoVeiculo estado);
        Task<IEnumerable<AuditoriaVeiculo>> ListAuditoria(Guid id);
    }
}
