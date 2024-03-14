using CaseVeiculo.Data.Data.db;
using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;
using CaseVeiculo.Domain.Model.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseVeiculo.Data.Data.repository.contracts
{
    public class baseRepository<T> : IbaseRepository<T> where T : class
    {
        protected DbSet<T> db;

        public baseRepository(AppDbContext context)
        {
            db = context.Set<T>();
        }

        

        public async Task<T> BuscarVeiculoPorId(Guid Id)
        {
            var VeiculoEspecifico = await db.FindAsync(Id);

            if (VeiculoEspecifico == null) return null;

            return VeiculoEspecifico;
        }
    }
}
