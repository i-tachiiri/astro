namespace Core.Application;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Domain.Entities.Astrology;
using Core.Domain.ValueObjects;
using Core.Application.Commands.CreateClient;

public interface IClientService
{
    Task<IReadOnlyList<Client>> GetClientsAsync(CancellationToken cancellationToken = default);
    Task<ClientId> CreateAsync(CreateClientDto dto, CancellationToken cancellationToken = default);
}
