using CaseVeiculo.Data.Data.db;
using CaseVeiculo.Data.Data.repository.contracts;
using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;
using CaseVeiculo.Domain.Model.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseVeiculo.Data.Data.repository
{
    public class VeiculoRepository : baseRepository<Veiculo>, IVeiculoRepository
    {
        private readonly AppDbContext _context;
        public VeiculoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AlterarEstado(Guid Id, EstadosDoVeiculo estado, DateTime dataDeAlteracao)
        {
            var veiculoEspecifico = await _context.Veiculos.FindAsync(Id);

            if (!IsValidTransition(veiculoEspecifico.Estado, estado))
                throw new Exception("Transição de estado inválida");

            veiculoEspecifico.Estado = estado;
            veiculoEspecifico.DataDeAlteracao = dataDeAlteracao;

            db.Update(veiculoEspecifico);
        }

        public bool IsValidTransition(EstadosDoVeiculo estadoAtual, EstadosDoVeiculo novoEstado)
        {
            switch (estadoAtual)
            {
                case EstadosDoVeiculo.Disponivel:
                    return novoEstado == EstadosDoVeiculo.Alugado ||
                           novoEstado == EstadosDoVeiculo.Manuntencao ||
                           novoEstado == EstadosDoVeiculo.Desativado;
                case EstadosDoVeiculo.Manuntencao:
                    return novoEstado == EstadosDoVeiculo.Disponivel ||
                           novoEstado == EstadosDoVeiculo.Desativado;
                case EstadosDoVeiculo.Alugado:
                    return novoEstado == EstadosDoVeiculo.Disponivel ||
                           novoEstado == EstadosDoVeiculo.Manuntencao;
                case EstadosDoVeiculo.Desativado:
                    return false;
                default:
                    return false;
            }
        }

        public async Task<IEnumerable<Veiculo>> ListarVeiculosPeloEstado(EstadosDoVeiculo estadoAtual)
        {
            var RetornoDaListaDoEstadoEspecifico =
                await _context.Veiculos.Where
                (VE => VE.Estado == estadoAtual)
                                .AsNoTracking()
                                .ToListAsync();

            return RetornoDaListaDoEstadoEspecifico;
        }
    }
}
