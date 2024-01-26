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
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
            services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ITabelaPrecoRepository, TabelaPrecoRepository>();
            services.AddScoped<IIdentificacaoPedidoRepository, IdentificacaoPedidoRepository>();
        }
    }
}