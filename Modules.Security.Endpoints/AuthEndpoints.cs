using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Modules.Security.Application.AuthService;
using Modules.Security.Application.AuthService.Commands.Login;
using Modules.Security.Application.AuthService.Commands.RefreshToken;
using Modules.Security.Application.AuthService.Commands.Register;
using Modules.Security.Application.Dtos;

namespace Modules.Security.Endpoints;

public static class AuthEndpoints
{
    public static void AddAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/register", ([FromBody]UserRegistrationForm registerUser, ISender sender) =>
        {
            var command = new RegisterCommand(registerUser);

            var result = sender.Send(command);

            return result;
        });

        app.MapPost("/login", ([FromBody]UserLoginForm userLogin, ISender sender) =>
        {
            var command = new LoginCommand(userLogin);

            var result = sender.Send(command);

            return result;
        });

        app.MapPost("/refresh-token", ([FromBody]TokenRequest tokenRequest, ISender sender) =>
        {
            var command = new RefreshTokenCommand(tokenRequest);

            var result = sender.Send(command);

            return result;
        });
    }
}
