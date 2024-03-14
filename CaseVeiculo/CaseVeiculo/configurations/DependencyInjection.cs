using CaseVeiculo.Application.Application.interfaces;
using CaseVeiculo.Application.Application.services;
using CaseVeiculo.Data.Data.db;
using CaseVeiculo.Data.Data.repository;
using CaseVeiculo.Data.Data.UoW;
using CaseVeiculo.Domain.Model.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseVeiculo.configurations
{
    public static class DependencyInjection
    {
        public static void InjetarDependencias(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(op => op.UseInMemoryDatabase("teste"));
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoService, VericuloService>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }
    }
}
