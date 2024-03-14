using CaseVeiculo.Application.Application.interfaces;
using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;
using CaseVeiculo.Domain.Model.interfaces;

namespace CaseVeiculo.Application.Application.services
{
    public class VericuloService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;
        private readonly IUnityOfWork _UoW;

        public VericuloService(IVeiculoRepository repository, IUnityOfWork uoW)
        {
            _repository = repository;
            _UoW = uoW;
        }

        public async Task AlterarEstado(Guid Id, EstadosDoVeiculo estado, DateTime dataDeAlteracao)
        {
            await _repository.AlterarEstado(Id, estado, dataDeAlteracao);
            await _UoW.SaveChangesAsync();
        }

        public async Task<Veiculo> BuscarVeiculoPorId(Guid Id)
            => await _repository.BuscarVeiculoPorId(Id);
            
        public bool IsValidTransition(EstadosDoVeiculo estadoAtual, EstadosDoVeiculo novoEstado)
            => _repository.IsValidTransition(estadoAtual, novoEstado);

        public Task<IEnumerable<Veiculo>> ListarVeiculosPeloEstado(EstadosDoVeiculo estadoAtual)
            => _repository.ListarVeiculosPeloEstado(estadoAtual);
            
        
    }
}
