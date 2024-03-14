using CaseVeiculo.Domain.Model.enums;

namespace CaseVeiculo.Application.Application.DTOs.viewModel
{
    public class VeiculoViewModel
    {
        public Guid Id { get; set; }
        public string MarcaDoVeiculo { get; set; }
        public EstadosDoVeiculo Estado { get; set; }
        public DateTime DataDeAlteracao { get; set; }


        public VeiculoViewModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
