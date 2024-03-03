using Microsoft.Extensions.Configuration;

namespace EventManagement.Application.DataAccess
{
    public static class ServiceRegistation
    {
        public static void AddDataAccessRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EventManagementContext>(option => option.UseSqlServer(configuration.GetConnectionString("SQLServer")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IEventParticipantsRepository, EventParticipantsRepository>();
        }
    }
}
