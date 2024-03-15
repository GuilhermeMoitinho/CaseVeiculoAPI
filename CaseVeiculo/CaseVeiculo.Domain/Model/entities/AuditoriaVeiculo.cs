using CaseVeiculo.Domain.Model.enums;
using System.Text.Json.Serialization;

namespace CaseVeiculo.Domain.Model.entities
{
    public class AuditoriaVeiculo : BaseEntity
    {
        public List<EstadosDoVeiculo> HistoricoDeEstados { get; set; }
        public Guid VeiculoId { get; set; }

        [JsonIgnore]
        public Veiculo Veiculo { get; set; }

        public AuditoriaVeiculo()
        {
            HistoricoDeEstados = new List<EstadosDoVeiculo>();
        }

    }
}
