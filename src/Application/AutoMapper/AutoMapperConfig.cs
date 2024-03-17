using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PedidoDTO, Pedido>().ReverseMap();
            CreateMap<ItemPedidoDTO, ItemPedido>().ReverseMap();
        }
    }
}