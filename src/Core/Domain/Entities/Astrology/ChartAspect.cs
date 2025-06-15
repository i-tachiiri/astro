namespace Core.Domain.Entities.Astrology;

public class ChartAspect
{
    public Guid Id { get; private set; }
    public Guid ChartDataId { get; private set; }
    public string AspectType { get; private set; } = string.Empty;
    public string BodyA { get; private set; } = string.Empty;
    public string BodyB { get; private set; } = string.Empty;
    public decimal Orb { get; private set; }

    public ChartAspect(Guid id, Guid chartDataId, string aspectType, string bodyA, string bodyB, decimal orb)
    {
        Id = id;
        ChartDataId = chartDataId;
        AspectType = aspectType;
        BodyA = bodyA;
        BodyB = bodyB;
        Orb = orb;
    }

    private ChartAspect() { }
}
