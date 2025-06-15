namespace Core.Application;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Domain.Entities.Astrology;
using Core.Domain.ValueObjects;
using Core.Application.Commands.CreateClient;
using Core.Application.Interfaces;
using MediatR;

public class ClientService : IClientService
{
    private readonly IMediator _mediator;
    private readonly IClientRepository _repository;

    public ClientService(IMediator mediator, IClientRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public Task<IReadOnlyList<Client>> GetClientsAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public Task<ClientId> CreateAsync(CreateClientDto dto, CancellationToken cancellationToken = default)
    {
        return _mediator.Send(new CreateClientCommand(dto), cancellationToken);
    }
}
