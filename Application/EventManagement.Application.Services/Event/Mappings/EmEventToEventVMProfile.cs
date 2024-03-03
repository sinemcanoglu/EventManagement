namespace EventManagement.Application.Services.Event.Mappings
{
    public class EmEventToEventVMProfile : Profile
    {
        public EmEventToEventVMProfile()
        {
            CreateMap<EmEvent, EventVM>()
             .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.EventName))            
             .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.EventDate));            
        }
    }
}
