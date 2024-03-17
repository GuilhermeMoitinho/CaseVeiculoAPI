namespace CaseVeiculo.Domain.Model.interfaces
{
    public interface IUnityOfWork
    {
        Task SaveChangesAsync();
    }
}
