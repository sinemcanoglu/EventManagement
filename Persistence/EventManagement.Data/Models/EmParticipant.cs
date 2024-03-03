using System;
using System.Collections.Generic;

namespace EventManagement.Persistence.Data.Models;

public partial class EmParticipant
{
    public int ParticipantId { get; set; }

    public string ParticipantName { get; set; } = null!;

    public string ParticipantEmail { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? SysLastUpdate { get; set; }

    public int? SysVersion { get; set; }

    public virtual ICollection<EmEventParticipant> EmEventParticipants { get; set; } = new List<EmEventParticipant>();
}
