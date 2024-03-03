namespace EventManagement.Application.ViewModels
{
    public class EventVM
    {
        public int EventId { get; set; }

        public string? EventName { get; set; }

        public DateTime? EventDate { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? SysLastUpdate { get; set; }

        public int? SysVersion { get; set; }


        public ICollection<ParticipantVM> Participants { get; set; } = new List<ParticipantVM>();
    }
}
