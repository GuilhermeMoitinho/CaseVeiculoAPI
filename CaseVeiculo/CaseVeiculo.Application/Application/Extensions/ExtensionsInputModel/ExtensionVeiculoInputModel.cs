using CaseVeiculo.Application.Application.DTOs.inpuModel;
using CaseVeiculo.Domain.Model.entities;

namespace CaseVeiculo.Application.Application.Extensions.ExtensionsInputModel
{
    public static class ExtensionVeiculoInputModel
    {
        public static Veiculo TransFormarEmEntidade(this VeiculoInpuModel inputModel)
        {
            var veiculoEntity = new Veiculo()
            {
                MarcaDoVeiculo = inputModel.MarcaDoVeiculo,
                DataDeAlteracao = inputModel.DataDeAlteracao,
                Estado = inputModel.Estado,
            };

            return veiculoEntity;
        }
    }
}
