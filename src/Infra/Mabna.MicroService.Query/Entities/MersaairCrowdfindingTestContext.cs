using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mabna.MicroService.Query.Entities;

public partial class MersaairCrowdfindingTestContext : DbContext
{
    public MersaairCrowdfindingTestContext()
    {
    }

    public MersaairCrowdfindingTestContext(DbContextOptions<MersaairCrowdfindingTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<Trade> Trades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("mersaair_crowdfundingTest");

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Instrument");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Trade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Trade");

            entity.Property(e => e.Close).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.DateEn).HasColumnType("datetime");
            entity.Property(e => e.High).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.Low).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.Open).HasColumnType("decimal(19, 4)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
