using System;

namespace Core.Application.Commands.CreateClient;

public record CreateClientDto(
    Guid AstrologerId,
    string Name,
    string? Email,
    DateTime BirthDate,
    TimeOnly BirthTime,
    decimal Lat,
    decimal Lon,
    string TimeZone);
