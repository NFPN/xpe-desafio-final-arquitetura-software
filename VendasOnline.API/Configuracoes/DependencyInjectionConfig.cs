using VendasOnline.Dominio.Interfaces;
using VendasOnline.Infraestrutura.Repositorios;
using VendasOnline.Servico.Servicos;

namespace VendasOnline.API.Configuracoes
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegistrarServicos(this IServiceCollection services)
        {
            // Repositórios
            services.AddScoped<IRepositorioProduto, RepositorioProduto>();
            services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            services.AddScoped<IRepositorioPedido, RepositorioPedido>();

            // Serviços
            services.AddScoped<IServicoProduto, ServicoProduto>();
            services.AddScoped<IServicoCliente, ServicoCliente>();
            services.AddScoped<IServicoPedido, ServicoPedido>();

            return services;
        }
    }
}
