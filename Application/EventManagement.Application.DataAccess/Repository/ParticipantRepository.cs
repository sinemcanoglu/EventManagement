namespace EventManagement.Application.DataAccess.Repository
{
    public class ParticipantRepository(EventManagementContext context) : GenericRepository<EmParticipant>(context), IParticipantRepository
    {
    }
}
