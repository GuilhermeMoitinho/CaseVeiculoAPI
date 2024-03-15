using CaseVeiculo.Application.Application.DTOs.viewModel;
using CaseVeiculo.Application.Application.interfaces;
using CaseVeiculo.Application.Application.serviceResponse;
using CaseVeiculo.Data.Data.db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseVeiculo.Controllers
{
    [Route("api/auditorias")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        private readonly IAuditoriaService _serviceAuditoria;

        public AuditoriaController(IAuditoriaService serviceAuditoria)
        {
            _serviceAuditoria = serviceAuditoria;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuditor(Guid id)
        {
           if (id == Guid.Empty) return BadRequest();

           var AuditoriaHistorico = await _serviceAuditoria.ListAuditoria(id);

            if (AuditoriaHistorico == null) return NotFound();

            var response = new Response(AuditoriaHistorico);

            return Ok(response);
        }
    }
}
