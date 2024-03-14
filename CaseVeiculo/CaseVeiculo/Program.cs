using CaseVeiculo.Application.Application.interfaces;
using CaseVeiculo.Application.Application.services;
using CaseVeiculo.configurations;
using CaseVeiculo.Data.Data.db;
using CaseVeiculo.Data.Data.repository;
using CaseVeiculo.Data.Data.repository.contracts;
using CaseVeiculo.Data.Data.UoW;
using CaseVeiculo.Domain.Model.entities;
using CaseVeiculo.Domain.Model.interfaces;
using CaseVeiculo.middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InjetarDependencias();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();

app.MapControllers();

app.Run();
