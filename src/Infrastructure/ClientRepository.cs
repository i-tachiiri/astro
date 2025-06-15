using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.Interfaces;
using Core.Domain.Entities.Astrology;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _db;

    public ClientRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Client client, BirthInfo birthInfo, CancellationToken cancellationToken = default)
    {
        _db.Clients.Add(client);
        _db.BirthInfos.Add(birthInfo);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Client>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _db.Clients.ToListAsync(cancellationToken);
    }
}
