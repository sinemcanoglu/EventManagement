namespace EventManagement.Application.Services.Event.Commands.Create
{
    public class CreateEventCommand : IRequest<bool>
    {
        public string? EventName { get; set; }
              
        public DateTime? EventDate { get; set; }

        public bool? IsActive { get; set; }     

    }
}
