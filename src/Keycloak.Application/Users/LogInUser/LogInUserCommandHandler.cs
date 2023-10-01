using Keycloak.Domain.Abstractions;
using Keycloak.Domain.Users;
using Keycloak.Application.Abstractions.Authentication;
using Keycloak.Application.Abstractions.Messaging;

namespace Keycloak.Application.Users.LogInUser;

internal sealed class LogInUserCommandHandler : ICommandHandler<LogInUserCommand, AccessTokenResponse>
{
    private readonly IJwtService _jwtService;

    public LogInUserCommandHandler(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public async Task<Result<AccessTokenResponse>> Handle(LogInUserCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _jwtService.GetAccessTokenAsync(
            request.Email,
            request.Password,
            cancellationToken);

        return result.IsFailure ? Result.Failure<AccessTokenResponse>(UserErrors.InvalidCredentials) : new AccessTokenResponse(result.Value);
    }
}