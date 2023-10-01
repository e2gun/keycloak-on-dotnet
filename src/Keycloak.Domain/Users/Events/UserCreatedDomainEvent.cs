using Keycloak.Domain.Abstractions;

namespace Keycloak.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;