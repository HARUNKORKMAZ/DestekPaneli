using Carter;
using DestekPaneli.Application.DTOs;
using DestekPaneli.Application.Interfaces.Repositories;

namespace DestekPaneli.WebAPI.Modules
{
    public class AuthModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder group)
        {
            var app = group.MapGroup("/api/auth").WithTags("Auth");
            app.MapPost("/register", async (RegisterRequestDto request, IAuthService authService) =>
            {
                var result = await authService.RegisterAsync(request);
                return Results.StatusCode(result.StatusCode);
            });

            app.MapPost("/login", async (LoginRequestDto request, IAuthService authService) =>
            {
                var result = await authService.LoginAsync(request);
                return Results.StatusCode(result.StatusCode);
            });
        }
    }
}
