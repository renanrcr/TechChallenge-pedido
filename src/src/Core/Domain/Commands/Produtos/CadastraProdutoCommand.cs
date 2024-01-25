﻿using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.Produtos
{
    public class CadastraProdutoCommand : IRequest<ProdutoDTO>
    {
        public Guid CategoriaProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }
}