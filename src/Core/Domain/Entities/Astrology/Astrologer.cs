namespace Core.Domain.Entities.Astrology;

public class Astrologer
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public byte[] PasswordHash { get; private set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; private set; } = Array.Empty<byte>();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Astrologer(Guid id, string name, string email, byte[] passwordHash, byte[] passwordSalt)
    {
        Id = id;
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    private Astrologer() { }
}
