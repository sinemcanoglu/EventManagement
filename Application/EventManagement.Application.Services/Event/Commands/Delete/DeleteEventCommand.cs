namespace EventManagement.Application.Services.Event.Commands.Delete
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public int EventId { get; set; }
    }
}
