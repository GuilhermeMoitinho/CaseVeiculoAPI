using CaseVeiculo.Application.Application.DTOs.viewModel;
using CaseVeiculo.Domain.Model.entities;

namespace CaseVeiculo.Application.Application.serviceResponse
{
    public class Response
    {
        public string Mensagem { get; set; }
        public Object Dados { get; set; }
        public bool Sucesso { get; set; }

        public Response(){}

        public Response(VeiculoViewModel viewModel)
        {
            Mensagem = "Requisição concluída com sucesso";
            Dados = viewModel;
            Sucesso = true;
        }

        public Response(IEnumerable<VeiculoViewModel> viewModel)
        {
            Mensagem = "Requisição concluída com sucesso";
            Dados = viewModel;
            Sucesso = true;
        }

        public Response(IEnumerable<AuditoriaVeiculo> viewModel)
        {
            Mensagem = "Requisição concluída com sucesso";
            Dados = viewModel;
            Sucesso = true;
        }
    }
}
