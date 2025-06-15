namespace Core.Domain.Entities.Astrology;

public class Interpretation
{
    public Guid Id { get; private set; }
    public Guid AstrologerId { get; private set; }
    public string ConditionKey { get; private set; } = string.Empty;
    public string Body { get; private set; } = string.Empty;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    public Interpretation(Guid id, Guid astrologerId, string conditionKey, string body)
    {
        Id = id;
        AstrologerId = astrologerId;
        ConditionKey = conditionKey;
        Body = body;
    }

    private Interpretation() { }
}
