using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Core.Application.Interfaces;
using Core.Domain.Entities.Astrology;
using Core.Domain.ValueObjects;

namespace Core.Application.Commands.CreateClient;

public class CreateClientHandler : IRequestHandler<CreateClientCommand, ClientId>
{
    private readonly IClientRepository _repository;

    public CreateClientHandler(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClientId> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var id = ClientId.New();
        var dto = request.Dto;
        var client = new Client(id.Value, dto.AstrologerId, dto.Name, dto.Email);
        var birthInfo = new BirthInfo(id.Value, dto.BirthDate, dto.BirthTime, dto.Lat, dto.Lon, dto.TimeZone);
        await _repository.AddAsync(client, birthInfo, cancellationToken);
        return id;
    }
}
