using CaseVeiculo.Application.Application.interfaces;
using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;
using CaseVeiculo.Domain.Model.interfaces;

namespace CaseVeiculo.Application.Application.services
{
    public class VericuloService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;
        private readonly IAuditoriaService _auditoriaService;
        private readonly IUnityOfWork _UoW;

        public VericuloService(IVeiculoRepository repository,
                               IAuditoriaService auditoriaService, 
                               IUnityOfWork uoW)
        {
            _repository = repository;
            _auditoriaService = auditoriaService;
            _UoW = uoW;
        }

        public async Task AddAsync(Veiculo veiculo)
        {
            await _repository.AddAsync(veiculo);
            await _auditoriaService.CriarHistoricoDeEstados(veiculo.Id, veiculo.Estado);
            await _UoW.SaveChangesAsync();
        }

        public async Task AlterarEstado(Guid Id, EstadosDoVeiculo estado)
        {
            await _repository.AlterarEstado(Id, estado);
            await _auditoriaService.AdicionarEstadosDoVeiculo(Id, estado);
            await _UoW.SaveChangesAsync();
        }

        public async Task<Veiculo> BuscarVeiculoPorId(Guid Id)
            => await _repository.BuscarVeiculoPorIdAsync(Id);
            
        public bool IsValidTransition(EstadosDoVeiculo estadoAtual, EstadosDoVeiculo novoEstado)
            => _repository.IsValidTransition(estadoAtual, novoEstado);

        public Task<IEnumerable<Veiculo>> ListarVeiculosPeloEstado(EstadosDoVeiculo estadoAtual, 
                                                                   int tamanhoPagina, 
                                                                   int indicePagina)
            => _repository.ListarVeiculosPeloEstado(estadoAtual, tamanhoPagina, indicePagina);
            
        
    }
}
