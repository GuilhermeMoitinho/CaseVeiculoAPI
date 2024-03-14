using CaseVeiculo.Domain.Model.enums;
using CaseVeiculo.Domain.Model;

namespace CaseVeiculo.Domain.Model.entities
{
    public class Veiculo : BaseEntity
    {
        public string MarcaDoVeiculo { get; set; }
        public EstadosDoVeiculo Estado { get; set; }

        public Veiculo(){}

        public Veiculo(string marcadoveiculo)
            => MarcaDoVeiculo = marcadoveiculo; 
            
        
    }
}
