using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TeamifiedLEPRSVPBE.Application.Interfaces;
using TeamifiedLEPRSVPBE.Application.Services;
using TeamifiedLEPRSVPBE.Core.Interfaces;
using TeamifiedLEPRSVPBE.Infrastructure.Data;
using TeamifiedLEPRSVPBE.Infrastructure.Repositories;

namespace TeamifiedLEPRSVPBE.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
             options.UseSqlite("Data Source=app.db"));

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();
            return services;
        }
    }
}
