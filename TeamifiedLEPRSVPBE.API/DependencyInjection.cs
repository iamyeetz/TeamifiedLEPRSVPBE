using TeamifiedLEPRSVPBE.Application;
using TeamifiedLEPRSVPBE.Infrastructure;

namespace TeamifiedLEPRSVPBE.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDi(this IServiceCollection services)
        {
            services.AddApplicationDI()
                    .AddInfrastructureDI();

            return services;
        }
    }
}
