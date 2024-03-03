namespace EventManagement.Application.Services.Event.Queries
{
    internal class GetEventByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetEventByIdQuery, EventVM>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<EventVM> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            EmEvent entity = await _unitOfWork.Events.GetByIdAsync(request.EventId);
            if (entity == null)
            {
                return null;
            }
            return _mapper.Map<EventVM>(entity);
        }
    }
}