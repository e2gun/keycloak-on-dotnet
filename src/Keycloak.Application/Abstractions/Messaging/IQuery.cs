using Keycloak.Domain.Abstractions;
using MediatR;

namespace Keycloak.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}