using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using VendasOnline.API.Configuracoes;
using VendasOnline.API.Middlewares;
using VendasOnline.API.Validadores;
using VendasOnline.Dominio.DTOs;
using VendasOnline.Infraestrutura.Contexto;
using static VendasOnline.API.Configuracoes.SwaggerConfig;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao container.
builder.Services.AddControllers();

// Adicionar fluent validation
builder.Services.AddMvc();
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddScoped<IValidator<ProdutoDto>, ProdutoValidator>();

// Adicionar suporte a AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// Adicionar contexto de banco de dados
builder.Services.AddDbContext<VendasOnlineDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar configuração de injeção de dependência
builder.Services.RegistrarServicos();

// Configurar Swagger
builder.Services.ConfigurarSwagger();

var app = builder.Build();

// Configurar o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

await app.RunAsync();
