using Application.Services;
using Domain.Adapters;
using Domain.Notificacoes;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModuleDependency
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
            services.AddSingleton<IMessageService, MessageService>();
        }
    }
}