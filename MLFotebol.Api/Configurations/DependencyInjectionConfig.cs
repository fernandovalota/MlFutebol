using MlFutebol.Bussiness.Interfaces.Repositories;
using MlFutebol.Bussiness.Interfaces.Services;
using MlFutebol.Bussiness.Notification;
using MlFutebol.Bussiness.Services;
using MlFutebol.Data.Context;
using MlFutebol.Data.Repository;

namespace MLFutebol.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolverDependecias(this IServiceCollection services)
        {
            //Data
            services.AddScoped<MlDbContext>();
            services.AddScoped<ITimeRepository, TimeRepository>();
            services.AddScoped<IJogadorRepository, JogadorRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IPosicaoRepository, PosicaoRepository>();

            //Business
            services.AddScoped<IJogadorService,JogadorService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
