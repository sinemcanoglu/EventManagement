namespace EventManagement.Application.DataAccess
{
    public class UnitOfWork(EventManagementContext dbContext) : IUnitOfWork, IAsyncDisposable
    {
        private readonly EventManagementContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        private bool _disposed = false;
        private IDbContextTransaction _currentTransaction;

        private EventRepository _events;
        private ParticipantRepository _participants;
        private EventParticipantsRepository _eventParticipants;

        public IEventRepository Events => _events ??= new EventRepository(_dbContext);

        public IParticipantRepository Participants => _participants ??= new ParticipantRepository(_dbContext);
       
        public IEventParticipantsRepository EventParticipants => _eventParticipants ??= new EventParticipantsRepository(_dbContext);

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                throw new InvalidOperationException("There is already an active transaction.");
            }

            _currentTransaction = await _dbContext.Database.BeginTransactionAsync();
            return _currentTransaction;
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await CompleteAsync();
                if (_currentTransaction != null)
                {
                    await _currentTransaction.CommitAsync();
                }
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.RollbackAsync();
                }
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (!_disposed)
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                }
                if (_dbContext != null)
                {
                    await _dbContext.DisposeAsync();
                }
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }

}
