namespace Core.Domain.Entities.Astrology;

public class Report
{
    public Guid Id { get; private set; }
    public Guid ClientId { get; private set; }
    public string ReportType { get; private set; } = string.Empty;
    public string FilePath { get; private set; } = string.Empty;
    public DateTime GeneratedAt { get; private set; } = DateTime.UtcNow;

    public Report(Guid id, Guid clientId, string reportType, string filePath)
    {
        Id = id;
        ClientId = clientId;
        ReportType = reportType;
        FilePath = filePath;
    }

    private Report() { }
}
