using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Persistence.Data.Models;

public partial class EventManagementContext : DbContext
{
    public EventManagementContext()
    {
    }

    public EventManagementContext(DbContextOptions<EventManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmEvent> EmEvents { get; set; }

    public virtual DbSet<EmEventParticipant> EmEventParticipants { get; set; }

    public virtual DbSet<EmParticipant> EmParticipants { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__EM_Event__7944C8706384E220");

            entity.ToTable("EM_Events");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SysLastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SysVersion).HasDefaultValue(1);
        });

        modelBuilder.Entity<EmEventParticipant>(entity =>
        {
            entity.HasKey(e => e.EventParticipantId).HasName("PK__EM_Event__09F32B72C7A5A43B");

            entity.ToTable("EM_EventParticipants");

            entity.Property(e => e.EventParticipantId).HasColumnName("EventParticipantID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            entity.Property(e => e.SysLastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SysVersion).HasDefaultValue(1);

            entity.HasOne(d => d.Event).WithMany(p => p.EmEventParticipants)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__EM_EventP__Event__60A75C0F");

            entity.HasOne(d => d.Participant).WithMany(p => p.EmEventParticipants)
                .HasForeignKey(d => d.ParticipantId)
                .HasConstraintName("FK__EM_EventP__Parti__619B8048");
        });

        modelBuilder.Entity<EmParticipant>(entity =>
        {
            entity.HasKey(e => e.ParticipantId).HasName("PK__EM_Parti__7227997E36960817");

            entity.ToTable("EM_Participants");

            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            entity.Property(e => e.ParticipantEmail)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.ParticipantName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SysLastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SysVersion).HasDefaultValue(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
