namespace Core.Domain.Entities.Astrology;

public class BirthInfo
{
    public Guid ClientId { get; private set; }
    public DateTime BirthDate { get; private set; }
    public TimeOnly BirthTime { get; private set; }
    public decimal Lat { get; private set; }
    public decimal Lon { get; private set; }
    public string TimeZone { get; private set; } = string.Empty;

    public BirthInfo(Guid clientId, DateTime birthDate, TimeOnly birthTime, decimal lat, decimal lon, string timeZone)
    {
        ClientId = clientId;
        BirthDate = birthDate;
        BirthTime = birthTime;
        Lat = lat;
        Lon = lon;
        TimeZone = timeZone;
    }

    private BirthInfo() { }
}
