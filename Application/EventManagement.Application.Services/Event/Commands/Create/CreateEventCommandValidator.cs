namespace EventManagement.Application.Services.Event.Commands.Create
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(command => command.EventName).NotEmpty().WithMessage("Event name is required.");
            RuleFor(command => command.EventDate).NotEmpty().WithMessage("Event date is required.");
        }
    }
}