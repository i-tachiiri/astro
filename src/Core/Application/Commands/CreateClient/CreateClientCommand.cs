using MediatR;
using Core.Domain.ValueObjects;

namespace Core.Application.Commands.CreateClient;

public record CreateClientCommand(CreateClientDto Dto) : IRequest<ClientId>;
