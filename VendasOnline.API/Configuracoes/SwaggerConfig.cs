using Microsoft.OpenApi.Models;

namespace VendasOnline.API.Configuracoes
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigurarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API de Vendas Online",
                    Version = "v1",
                    Description = "API REST para gerenciamento de vendas online",
                    Contact = new OpenApiContact
                    {
                        Name = "Seu Nome",
                        Email = "seu.email@exemplo.com"
                    }
                });
            });

            return services;
        }
    }
}
