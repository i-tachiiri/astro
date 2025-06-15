namespace Core.Domain.Entities.Astrology;

public class Client
{
    public Guid Id { get; private set; }
    public Guid AstrologerId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Email { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Client(Guid id, Guid astrologerId, string name, string? email)
    {
        Id = id;
        AstrologerId = astrologerId;
        Name = name;
        Email = email;
    }

    private Client() { }
}
