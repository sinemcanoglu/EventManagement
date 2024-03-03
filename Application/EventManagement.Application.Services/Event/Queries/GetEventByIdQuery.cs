namespace EventManagement.Application.Services.Event.Queries
{
    public class GetEventByIdQuery : IRequest<EventVM>
    {
        public int EventId { get; set; }
    }
}
