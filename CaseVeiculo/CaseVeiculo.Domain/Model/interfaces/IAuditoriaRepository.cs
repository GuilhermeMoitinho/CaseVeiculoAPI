using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseVeiculo.Domain.Model.interfaces
{
    public interface IAuditoriaRepository
    {
        Task AdicionarEstadosDoVeiculo(Guid Id, EstadosDoVeiculo estado);
        Task CriarHistoricoDeEstados(Guid Id, EstadosDoVeiculo estado);
        Task<IEnumerable<AuditoriaVeiculo>> ListAuditoria(Guid id);
    }
}
