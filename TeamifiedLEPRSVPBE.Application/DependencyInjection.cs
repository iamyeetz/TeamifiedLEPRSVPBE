using Microsoft.Extensions.DependencyInjection;
using TeamifiedLEPRSVPBE.Application.Interfaces;
using TeamifiedLEPRSVPBE.Application.Services;

namespace TeamifiedLEPRSVPBE.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            return services;
        }
    }
}
