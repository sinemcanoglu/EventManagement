using System;
using System.Collections.Generic;

namespace EventManagement.Persistence.Data.Models;

public partial class EmEvent
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public DateTime? EventDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? SysLastUpdate { get; set; }

    public int? SysVersion { get; set; }

    public virtual ICollection<EmEventParticipant> EmEventParticipants { get; set; } = new List<EmEventParticipant>();
}
