using CaseVeiculo.Data.Data.db;
using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.enums;
using CaseVeiculo.Domain.Model.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaseVeiculo.Data.Data.repository
{
    public class AuditoriaRepository : IAuditoriaRepository
    {
        private readonly AppDbContext _context;

        public AuditoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuditoriaVeiculo>> ListAuditoria(Guid id)
        {
            var veiculoEspecifico = await _context.AuditoriaDoVeiculo
                       .FirstOrDefaultAsync(va => va.VeiculoId == id);

            if (veiculoEspecifico == null) return null;

            var retorno = new List<AuditoriaVeiculo> { veiculoEspecifico };

            return retorno;
        }


        public async Task AdicionarEstadosDoVeiculo(Guid Id, EstadosDoVeiculo estado)
        {
            var auditoriaVeiculo = await _context.AuditoriaDoVeiculo
                                           .FirstOrDefaultAsync(a => a.VeiculoId == Id);

            if (auditoriaVeiculo == null)
            {
                auditoriaVeiculo = new AuditoriaVeiculo
                {
                    VeiculoId = Id,
                    HistoricoDeEstados = new List<EstadosDoVeiculo> { estado }
                };
                _context.AuditoriaDoVeiculo.Add(auditoriaVeiculo);
            }
            else
            {
                auditoriaVeiculo.HistoricoDeEstados.Add(estado);
            }
        }

        public async Task CriarHistoricoDeEstados(Guid Id, EstadosDoVeiculo estado)
        {
            var auditoria = new AuditoriaVeiculo
            {
                VeiculoId = Id,
                HistoricoDeEstados = new List<EstadosDoVeiculo> { estado }
            };

            await _context.AuditoriaDoVeiculo.AddAsync(auditoria);
        }
    }
}
