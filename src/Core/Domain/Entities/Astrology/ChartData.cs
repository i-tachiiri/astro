namespace Core.Domain.Entities.Astrology;

public class ChartData
{
    public Guid ClientId { get; private set; }
    public string PlanetPositions { get; private set; } = string.Empty;
    public string HouseCusps { get; private set; } = string.Empty;
    public DateTime CalculatedAt { get; private set; } = DateTime.UtcNow;

    public ChartData(Guid clientId, string planetPositions, string houseCusps)
    {
        ClientId = clientId;
        PlanetPositions = planetPositions;
        HouseCusps = houseCusps;
    }

    private ChartData() { }
}
