using AutoMapper;
using VendasOnline.Dominio.DTOs;
using VendasOnline.Dominio.Entidades;

namespace VendasOnline.API.Configuracoes
{
    public static partial class SwaggerConfig
    {
        /// <summary>
        /// Configuração do AutoMapper
        /// </summary>
        public class AutoMapperConfig : Profile
        {
            public AutoMapperConfig()
            {
                CreateMap<Produto, ProdutoDto>().ReverseMap();
                CreateMap<Cliente, ClienteDto>().ReverseMap();
                CreateMap<Pedido, PedidoDto>().ReverseMap();
                CreateMap<ItemPedido, ItemPedidoDto>().ReverseMap();
            }
        }
    }
}
