using CaseVeiculo.Application.Application.interfaces;
using CaseVeiculo.Data.Data.db;
using CaseVeiculo.Domain.Model.enums;
using Microsoft.AspNetCore.Mvc;
using CaseVeiculo.Application.Application.Extensions.ExtensionsViewModel;
using CaseVeiculo.Application.Application.serviceResponse;
using CaseVeiculo.Application.Application.DTOs.inpuModel;
using CaseVeiculo.Application.Application.Extensions.ExtensionsInputModel;

namespace CaseVeiculo.Controllers
{
    [Route("api/v1/veiculos")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
   
        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPatch]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AlterarEstado(Guid Id, EstadosDoVeiculo estado, DateTime horaDaAlteracao)
        {
            if (Id == Guid.Empty) return BadRequest();

            var VeiculoEspecifico = await _veiculoService.BuscarVeiculoPorId(Id);
            var IfValidTransition = _veiculoService.IsValidTransition(VeiculoEspecifico.Estado, estado);

            if (!IfValidTransition) return BadRequest("Transação inválida");

            if (horaDaAlteracao > DateTime.Now)
                return BadRequest("Não é permitido inserir uma operação de alteração de estado no futuro");

            await _veiculoService.AlterarEstado(Id, estado, DateTime.Now);

            return NoContent();
        }


        [ActionName("BuscarVeiculoPorId")]
        [HttpGet("{Id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> BuscarVeiculoPorId(Guid Id)
        {
            if (Id == Guid.Empty) return BadRequest();

            var veiculoEntity =  await _veiculoService.BuscarVeiculoPorId(Id);
            var VeiculoViewModel = veiculoEntity.TransFormarEmViewModel();
            var response = new Response(VeiculoViewModel);

            return Ok(response);
        }          
        

        [HttpGet("{estadoAtual}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetVeiculosPeloEstado(EstadosDoVeiculo estadoAtual)
        {

            if(estadoAtual == null) return BadRequest();

            var ListaDeVeiculos = await _veiculoService.ListarVeiculosPeloEstado(estadoAtual);

            if (ListaDeVeiculos == null) return NotFound();

            var viewModelList = ListaDeVeiculos.TransformarEmListaDeViewModel();

            var response = new Response(viewModelList);

            return Ok(response);
        }
                 

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CriarVeiculo(VeiculoInpuModel inputModel)
        {
            if (inputModel is null) return BadRequest();

            var veiculo = inputModel.TransFormarEmEntidade();

            await _veiculoService.AddAsync(veiculo);

            var viewModel = veiculo.TransFormarEmViewModel();

            var response = new Response(viewModel);

            return CreatedAtAction(nameof(BuscarVeiculoPorId), new {Id = veiculo.Id }, response);
        }
    }
}
