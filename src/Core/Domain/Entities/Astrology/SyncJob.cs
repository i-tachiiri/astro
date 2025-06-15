namespace Core.Domain.Entities.Astrology;

public class SyncJob
{
    public Guid Id { get; private set; }
    public Guid AstrologerId { get; private set; }
    public string JobType { get; private set; } = string.Empty;
    public string Status { get; private set; } = string.Empty;
    public DateTime StartedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? EndedAt { get; private set; }
    public string? ErrorMsg { get; private set; }

    public SyncJob(Guid id, Guid astrologerId, string jobType)
    {
        Id = id;
        AstrologerId = astrologerId;
        JobType = jobType;
        Status = "Pending";
    }

    private SyncJob() { }
}
