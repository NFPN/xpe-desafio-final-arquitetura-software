using Microsoft.EntityFrameworkCore;
using VendasOnline.API.Configuracoes;
using VendasOnline.Infraestrutura.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao container.
builder.Services.AddControllers();

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

app.MapControllers();

await app.RunAsync();
