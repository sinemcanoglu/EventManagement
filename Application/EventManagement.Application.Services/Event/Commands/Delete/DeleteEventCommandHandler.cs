namespace EventManagement.Application.Services.Event.Commands.Delete
{
    public class DeleteEventCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteEventCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var entity = await _unitOfWork.Events.GetByIdAsync(request.EventId);
              
                await _unitOfWork.Events.DeleteAsync(entity);
                await _unitOfWork.EventParticipants.DeleteByEventIdAsync(request.EventId);
               
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
