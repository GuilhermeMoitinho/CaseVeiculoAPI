using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseVeiculo.Application.Application.interfaces
{
    public interface IAuditoriaService
    {
        Task AdicionarEstadosDoVeiculo(Guid Id, EstadosDoVeiculo estado);
        Task CriarHistoricoDeEstados(Guid Id, EstadosDoVeiculo estado);
        Task<   IEnumerable<AuditoriaVeiculo>> ListAuditoria(Guid id);
    }
}
