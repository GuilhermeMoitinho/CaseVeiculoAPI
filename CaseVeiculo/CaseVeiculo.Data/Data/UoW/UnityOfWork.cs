using CaseVeiculo.Data.Data.db;
using CaseVeiculo.Domain.Model.interfaces;

namespace CaseVeiculo.Data.Data.UoW
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly AppDbContext _context;

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
