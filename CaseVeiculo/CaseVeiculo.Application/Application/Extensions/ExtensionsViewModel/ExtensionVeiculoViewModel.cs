using CaseVeiculo.Application.Application.DTOs.inpuModel;
using CaseVeiculo.Application.Application.DTOs.viewModel;
using CaseVeiculo.Domain.Model.entities;

namespace CaseVeiculo.Application.Application.Extensions.ExtensionsViewModel
{
    public static class ExtensionVeiculoViewModel
    {
        public static VeiculoViewModel TransFormarEmViewModel
            (this Veiculo veiculoEntity)
        {
            var viewModel = new VeiculoViewModel()
            {
                Id = veiculoEntity.Id,
                Estado = veiculoEntity.Estado,
                MarcaDoVeiculo = veiculoEntity.MarcaDoVeiculo
            };

            return viewModel;   
        }

        public static IEnumerable<VeiculoViewModel> TransformarEmListaDeViewModel
            (this IEnumerable<Veiculo> veiculoListEntity)
                => veiculoListEntity.Select(ve => ve.TransFormarEmViewModel()).ToList();         
    }
}
