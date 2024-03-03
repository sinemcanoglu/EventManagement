namespace EventManagement.Application.DataAccess.Interfaces
{
    public interface IEventParticipantsRepository : IGenericRepository<EmEventParticipant>
    {
        Task DeleteByEventIdAsync(int eventId);
        IQueryable<EmEventParticipant> GetByEventIdAsync(int eventId);
    }
}
