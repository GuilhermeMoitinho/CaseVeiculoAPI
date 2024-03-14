using CaseVeiculo.Application.Application.DTOs.viewModel;

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
    }
}
