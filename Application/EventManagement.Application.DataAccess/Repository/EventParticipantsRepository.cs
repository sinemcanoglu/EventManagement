namespace EventManagement.Application.DataAccess.Repository
{
    public class EventParticipantsRepository(EventManagementContext context) : GenericRepository<EmEventParticipant>(context), IEventParticipantsRepository
    {
        public async Task DeleteByEventIdAsync(int eventId)
        {           
            var entities = GetByEventIdAsync(eventId);                        
            _context.EmEventParticipants.RemoveRange(entities);
                      
            await _context.SaveChangesAsync();
        }

        public IQueryable<EmEventParticipant> GetByEventIdAsync(int eventId)
        {
            return _context.EmEventParticipants.Where(ep => ep.EventId == eventId).AsNoTracking();
        }

    }
}
