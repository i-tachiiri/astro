namespace Core.Domain.Entities.Astrology;

public class ChartImage
{
    public Guid Id { get; private set; }
    public Guid ChartDataId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string FilePath { get; private set; } = string.Empty;
    public string? BlobUrl { get; private set; }
    public int WidthPx { get; private set; }
    public int HeightPx { get; private set; }
    public int Dpi { get; private set; }
    public DateTime UploadedAt { get; private set; } = DateTime.UtcNow;

    public ChartImage(Guid id, Guid chartDataId, string name, string filePath)
    {
        Id = id;
        ChartDataId = chartDataId;
        Name = name;
        FilePath = filePath;
    }

    private ChartImage() { }
}
