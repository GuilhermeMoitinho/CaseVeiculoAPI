using System.Text.Json.Serialization;

namespace CaseVeiculo.Domain.Model.enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadosDoVeiculo 
    {
        Disponivel,
        Manuntencao,
        Alugado,
        Desativado
    }
}
