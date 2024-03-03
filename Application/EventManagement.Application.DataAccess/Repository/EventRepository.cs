namespace EventManagement.Application.DataAccess.Repository
{
    public class EventRepository(EventManagementContext context) : GenericRepository<EmEvent>(context), IEventRepository
    {
    }
}
