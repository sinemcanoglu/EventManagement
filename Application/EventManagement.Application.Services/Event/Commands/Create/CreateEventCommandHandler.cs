namespace EventManagement.Application.Services.Event.Commands.Create
{
    public class CreateEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateEventCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<bool> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var eventEntity = _mapper.Map<EmEvent>(request);
                await _unitOfWork.Events.AddAsync(eventEntity);

                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch
            {
                if (transaction != null)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                }
                return false;
            }
        }
    }
}
