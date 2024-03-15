using CaseVeiculo.Domain.Model.enums;
using CaseVeiculo.Domain.Model;
using System.Text.Json.Serialization;

namespace CaseVeiculo.Domain.Model.entities
{
    public class Veiculo : BaseEntity
    {
        public string MarcaDoVeiculo { get; set; }
        public EstadosDoVeiculo Estado { get; set; }

        [JsonIgnore]
        public AuditoriaVeiculo AuditoriaDoVeiculo { get; set; }

        public Veiculo(){}

        public Veiculo(string marcadoveiculo)
            => MarcaDoVeiculo = marcadoveiculo; 
            
        
    }
}
