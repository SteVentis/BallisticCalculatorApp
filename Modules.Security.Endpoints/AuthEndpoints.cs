using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Modules.Security.Application.Dtos;
using Modules.Security.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Modules.Security.Endpoints;

public static class AuthEndpoints
{
    public static void AddAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/register", ([FromBody]UserRegistrationForm registerUser, IAuthService authService) =>
        {
            var result = authService.Register(registerUser);

            return result;
        });

        app.MapPost("/login", ([FromBody]UserLoginForm userLogin, IAuthService authService) =>
        {
            var result = authService.Login(userLogin);

            return result;
        });

        app.MapPost("/refresh-token", ([FromBody] TokenRequest tokenRequest, IAuthService authService) =>
        {
            var result = authService.RefreshToken(tokenRequest);

            return result;
        });//.RequireAuthorization("User", "SuperUser", "Administrator");
    }
}
