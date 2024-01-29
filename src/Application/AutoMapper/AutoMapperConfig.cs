﻿using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<IdentificacaoPedidoDTO, IdentificacaoPedido>().ReverseMap();
            CreateMap<PedidoDTO, Pedido>().ReverseMap();
            CreateMap<ItemPedidoDTO, ItemPedido>().ReverseMap();
        }
    }
}