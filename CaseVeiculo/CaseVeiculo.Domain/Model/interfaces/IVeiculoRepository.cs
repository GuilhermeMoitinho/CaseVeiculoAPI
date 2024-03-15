using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseVeiculo.Domain.Model.interfaces
{
    public interface IVeiculoRepository : IbaseRepository<Veiculo>
    {
        Task AlterarEstado(Guid Id, EstadosDoVeiculo estado);
        bool IsValidTransition(EstadosDoVeiculo estadoAtual, EstadosDoVeiculo novoEstado);
        Task<IEnumerable<Veiculo>> ListarVeiculosPeloEstado(EstadosDoVeiculo estadoAtual);
        Task AddAsync(Veiculo veiculo);
    }
}
