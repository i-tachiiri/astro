using System;

namespace Core.Domain.ValueObjects;

public readonly struct ClientId
{
    public Guid Value { get; }

    public ClientId(Guid value)
    {
        Value = value;
    }

    public static ClientId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}
