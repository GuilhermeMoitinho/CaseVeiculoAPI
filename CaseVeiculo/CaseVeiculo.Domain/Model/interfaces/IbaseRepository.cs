using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;

namespace CaseVeiculo.Domain.Model.interfaces
{
    public interface IbaseRepository<T> where T : class
    { 
        Task<T> BuscarVeiculoPorId(Guid Id);
    }
}
