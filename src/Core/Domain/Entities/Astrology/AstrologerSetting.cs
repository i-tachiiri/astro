namespace Core.Domain.Entities.Astrology;

public class AstrologerSetting
{
    public Guid AstrologerId { get; private set; }
    public string HouseSystem { get; private set; } = "Placidus";
    public string SectionOrderRule { get; private set; } = "planetsFirst";
    public bool DeduplicateAspect { get; private set; }
    public string? DefaultBgImagePath { get; private set; }
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    public AstrologerSetting(Guid astrologerId)
    {
        AstrologerId = astrologerId;
    }

    private AstrologerSetting() { }
}
