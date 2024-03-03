namespace EventManagement.Application.Services.Event.Queries
{
    public class GetAllEventsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllEventsQuery, IEnumerable<EventVM>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<EventVM>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<EmEvent> events = _unitOfWork.Events.GetAll();
            return _mapper.Map<IEnumerable<EventVM>>(events);
        }
    }
}
