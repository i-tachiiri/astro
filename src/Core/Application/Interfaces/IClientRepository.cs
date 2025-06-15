using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Domain.Entities.Astrology;

namespace Core.Application.Interfaces;

public interface IClientRepository
{
    Task AddAsync(Client client, BirthInfo birthInfo, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Client>> GetAllAsync(CancellationToken cancellationToken = default);
}
