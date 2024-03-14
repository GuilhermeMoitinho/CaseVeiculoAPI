using CaseVeiculo.Domain.Model.enums;

namespace CaseVeiculo.Application.Application.DTOs.inpuModel
{
    public class VeiculoInpuModel
    {
        public Guid Id { get; set; }
        public string MarcaDoVeiculo { get; set; }
        public EstadosDoVeiculo Estado { get; set; }
        public DateTime DataDeAlteracao { get; set; }


        public VeiculoInpuModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
