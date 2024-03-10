using Domain.Adapters;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class InfraModuleDependency
    {
        public static void AddInfraModule(this IServiceCollection services)
        {
            services.AddScoped<DataBaseContext>();
            services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IIdentificacaoPedidoRepository, IdentificacaoPedidoRepository>();
            services.AddSingleton<IMessageService, MessageServiceRepository>();
        }
    }
}