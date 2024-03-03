using System;
using System.Collections.Generic;

namespace EventManagement.Persistence.Data.Models;

public partial class EmEventParticipant
{
    public int EventParticipantId { get; set; }

    public int? EventId { get; set; }

    public int? ParticipantId { get; set; }

    public DateTime? SysLastUpdate { get; set; }

    public int? SysVersion { get; set; }

    public virtual EmEvent? Event { get; set; }

    public virtual EmParticipant? Participant { get; set; }
}
