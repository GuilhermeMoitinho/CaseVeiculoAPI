using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;
using CaseVeiculo.Domain.Model.interfaces;

namespace CaseVeiculo.Application.Application.interfaces
{
    public interface IVeiculoService 
    {
        Task AlterarEstado(Guid Id, EstadosDoVeiculo estado, DateTime dataDeAlteracao);
        bool IsValidTransition(EstadosDoVeiculo estadoAtual, EstadosDoVeiculo novoEstado);
        Task<Veiculo> BuscarVeiculoPorId(Guid Id);
        Task AddAsync(Veiculo veiculo);
        Task<IEnumerable<Veiculo>> ListarVeiculosPeloEstado(EstadosDoVeiculo estadoAtual);
    }
}
