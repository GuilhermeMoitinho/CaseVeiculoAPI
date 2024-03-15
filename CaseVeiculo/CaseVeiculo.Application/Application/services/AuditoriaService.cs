using CaseVeiculo.Application.Application.interfaces;
using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;
using CaseVeiculo.Domain.Model.interfaces;

namespace CaseVeiculo.Application.Application.services
{
    public class AuditoriaService : IAuditoriaService
    {
        private readonly IAuditoriaRepository _repository;

        public AuditoriaService(IAuditoriaRepository repository)
        => _repository = repository;


        public async Task CriarHistoricoDeEstados(Guid Id, EstadosDoVeiculo estado)
        => await _repository.CriarHistoricoDeEstados(Id, estado);



        public async Task AdicionarEstadosDoVeiculo(Guid Id, EstadosDoVeiculo estado)
        =>  await _repository.AdicionarEstadosDoVeiculo(Id, estado);
            
        

        public async Task<IEnumerable<AuditoriaVeiculo>> ListAuditoria(Guid id)
        =>  await _repository.ListAuditoria(id);
             
        
    }
}
