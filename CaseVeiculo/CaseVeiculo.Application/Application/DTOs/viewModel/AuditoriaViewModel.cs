using CaseVeiculo.Domain.Model.enums;

namespace CaseVeiculo.Application.Application.DTOs.viewModel
{
    public class AuditoriaViewModel
    {
        public List<EstadosDoVeiculo> HistoricoDeEstados { get; set; }
        public Guid VeiculoId { get; set; }

        public AuditoriaViewModel()
        {
            HistoricoDeEstados = new List<EstadosDoVeiculo>();
        }
    }
}
