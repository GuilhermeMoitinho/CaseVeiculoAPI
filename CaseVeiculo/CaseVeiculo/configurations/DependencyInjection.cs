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
        public static void InjetarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnect = configuration.GetConnectionString("ConexaoPadrao");

            services.AddDbContext<AppDbContext>(op => op.UseSqlServer(dbConnect));
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();

            services.AddScoped<IVeiculoService, VericuloService>();
            services.AddScoped<IAuditoriaService, AuditoriaService>();

            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }
    }
}
