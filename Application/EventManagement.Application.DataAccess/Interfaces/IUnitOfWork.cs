namespace EventManagement.Application.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IEventRepository Events { get; }
        IParticipantRepository Participants { get; }

        IEventParticipantsRepository EventParticipants { get; }


        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
