using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.Commands.CreateClient;
using Core.Application.Interfaces;
using Core.Domain.Entities.Astrology;
using Core.Domain.ValueObjects;
using Xunit;

namespace Unit.Tests.Application.Commands.CreateClient;

public class CreateClientHandlerTests
{
    private class InMemoryClientRepository : IClientRepository
    {
        public List<Client> Clients { get; } = new();
        public List<BirthInfo> BirthInfos { get; } = new();

        public Task AddAsync(Client client, BirthInfo birthInfo, CancellationToken cancellationToken = default)
        {
            Clients.Add(client);
            BirthInfos.Add(birthInfo);
            return Task.CompletedTask;
        }

        public Task<IReadOnlyList<Client>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult((IReadOnlyList<Client>)Clients);
        }
    }

    [Fact]
    public async Task Handle_Adds_Client_And_BirthInfo()
    {
        var repo = new InMemoryClientRepository();
        var handler = new CreateClientHandler(repo);
        var dto = new CreateClientDto(Guid.NewGuid(), "Alice", "a@example.com", new DateTime(1990, 1, 1), new TimeOnly(12, 0), 35.0m, 139.0m, "Asia/Tokyo");
        var command = new CreateClientCommand(dto);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Single(repo.Clients);
        Assert.Single(repo.BirthInfos);
        var client = repo.Clients[0];
        Assert.Equal(result.Value, client.Id);
        Assert.Equal(dto.Name, client.Name);
        var birth = repo.BirthInfos[0];
        Assert.Equal(client.Id, birth.ClientId);
        Assert.Equal(dto.BirthDate, birth.BirthDate);
    }
}
