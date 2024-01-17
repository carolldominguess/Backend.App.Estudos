using Mttechne.Backend.Junior.Domain.Interfaces;
using Mttechne.Backend.Junior.Infra.Context;
using Mttechne.Backend.Junior.Infra.Data;
using Mttechne.Backend.Junior.Infra.Repository;
using Mttechne.Backend.Junior.Services.Interfaces;
using Mttechne.Backend.Junior.Services.Notificacoes;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.Interface.Configs
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region Infra
            services.AddScoped<MttechneDbContext>();
            services.AddScoped<MttechneDbContextFactory>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            #endregion

            #region Services
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<INotificador, Notificador>();
            #endregion

            return services;
        }
    }
}
