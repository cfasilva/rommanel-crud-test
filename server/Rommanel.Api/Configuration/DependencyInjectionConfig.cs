using Rommanel.Domain.Command;
using Rommanel.Domain.Interfaces.IService;
using Rommanel.Domain.Query;
using Rommanel.Infra.Context;
using Rommanel.Service;

namespace Rommanel.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped<ClienteCommandHandler>();
            services.AddScoped<ClienteQueryHandler>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddHttpClient();
        }
    }
}
