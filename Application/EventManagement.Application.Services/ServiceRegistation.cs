namespace EventManagement.Application.Services
{
    public static class ServiceRegistation
    {
        public static IServiceCollection AddServicesRegistration(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateEventCommandHandler).Assembly);
            services.AddMediatR(typeof(DeleteEventCommandHandler).Assembly);
            services.AddMediatR(typeof(GetAllEventsQueryHandler).Assembly);
            services.AddMediatR(typeof(GetEventByIdQueryHandler).Assembly);
            services.AddAutoMapper(typeof(CreateEventCommandToEventProfile).Assembly);
            services.AddAutoMapper(typeof(EmEventToEventVMProfile).Assembly);

            return services;
        }
    }
}
