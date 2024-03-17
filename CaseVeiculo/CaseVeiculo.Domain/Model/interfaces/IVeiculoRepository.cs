using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;

namespace CaseVeiculo.Domain.Model.interfaces
{
    public interface IVeiculoRepository : IbaseRepository<Veiculo>
    {
        Task AlterarEstado(Guid Id, EstadosDoVeiculo estado);
        bool IsValidTransition(EstadosDoVeiculo estadoAtual, EstadosDoVeiculo novoEstado);
        Task<IEnumerable<Veiculo>> ListarVeiculosPeloEstado(EstadosDoVeiculo estadoAtual, 
                                                            int tamanhoPagina,
                                                            int indicePagina);
    }
}
