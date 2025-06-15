using Core.Domain.Entities;
using Core.Domain.Entities.Astrology;
using Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Note> Notes => Set<Note>();
    public DbSet<Astrologer> Astrologers => Set<Astrologer>();
    public DbSet<AstrologerSetting> AstrologerSettings => Set<AstrologerSetting>();
    public DbSet<Interpretation> Interpretations => Set<Interpretation>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<BirthInfo> BirthInfos => Set<BirthInfo>();
    public DbSet<ChartData> ChartData => Set<ChartData>();
    public DbSet<ChartAspect> ChartAspects => Set<ChartAspect>();
    public DbSet<ChartHouse> ChartHouses => Set<ChartHouse>();
    public DbSet<ChartImage> ChartImages => Set<ChartImage>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<ReportSection> ReportSections => Set<ReportSection>();
    public DbSet<SyncJob> SyncJobs => Set<SyncJob>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Note>()
            .Property(n => n.Id)
            .HasConversion(id => id.Value, v => new NoteId(v));

        modelBuilder.Entity<AstrologerSetting>()
            .HasKey(a => a.AstrologerId);

        modelBuilder.Entity<BirthInfo>()
            .HasKey(b => b.ClientId);

        modelBuilder.Entity<ChartData>()
            .HasKey(c => c.ClientId);

        modelBuilder.Entity<ChartAspect>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<ChartHouse>()
            .HasKey(h => h.Id);

        modelBuilder.Entity<ChartImage>()
            .HasKey(i => i.Id);

        modelBuilder.Entity<ReportSection>()
            .HasIndex(r => new { r.ReportId, r.SortOrder });

        modelBuilder.Entity<Interpretation>()
            .HasIndex(i => i.ConditionKey);
    }
}
