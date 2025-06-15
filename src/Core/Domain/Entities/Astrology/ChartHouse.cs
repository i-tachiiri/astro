namespace Core.Domain.Entities.Astrology;

public class ChartHouse
{
    public Guid Id { get; private set; }
    public Guid ChartDataId { get; private set; }
    public int HouseNo { get; private set; }
    public string Body { get; private set; } = string.Empty;

    public ChartHouse(Guid id, Guid chartDataId, int houseNo, string body)
    {
        Id = id;
        ChartDataId = chartDataId;
        HouseNo = houseNo;
        Body = body;
    }

    private ChartHouse() { }
}
