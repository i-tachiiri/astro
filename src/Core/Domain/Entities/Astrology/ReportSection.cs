namespace Core.Domain.Entities.Astrology;

public class ReportSection
{
    public Guid Id { get; private set; }
    public Guid ReportId { get; private set; }
    public string SectionKind { get; private set; } = string.Empty;
    public string? Heading { get; private set; }
    public bool ShowHeading { get; private set; } = true;
    public string? BackgroundImagePath { get; private set; }
    public string Body { get; private set; } = string.Empty;
    public int Level { get; private set; }
    public int SortOrder { get; private set; }

    public ReportSection(Guid id, Guid reportId, string sectionKind, string body, int sortOrder)
    {
        Id = id;
        ReportId = reportId;
        SectionKind = sectionKind;
        Body = body;
        SortOrder = sortOrder;
    }

    private ReportSection() { }
}
