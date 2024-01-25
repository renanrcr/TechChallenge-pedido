﻿using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.Clientes
{
    public class CadastraClienteCommand : IRequest<ClienteDTO>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
}