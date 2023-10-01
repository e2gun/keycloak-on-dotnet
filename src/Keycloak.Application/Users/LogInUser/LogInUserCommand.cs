using Keycloak.Application.Abstractions.Messaging;

namespace Keycloak.Application.Users.LogInUser;

public sealed record LogInUserCommand(string Email, string Password) : ICommand<AccessTokenResponse>;