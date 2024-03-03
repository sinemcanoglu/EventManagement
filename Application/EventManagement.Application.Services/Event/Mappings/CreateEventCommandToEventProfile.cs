namespace EventManagement.Application.Services.Event.Mappings
{
    public class CreateEventCommandToEventProfile : Profile
    {
        public CreateEventCommandToEventProfile()
        {
            CreateMap<CreateEventCommand, EmEvent>()
              .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.EventName));
           
              ////  .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.EventDate))
              //.ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId));
        }
    }
}
