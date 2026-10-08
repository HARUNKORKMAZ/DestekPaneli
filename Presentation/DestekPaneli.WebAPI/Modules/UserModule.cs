using Carter;

namespace DestekPaneli.WebAPI.Modules
{
    public sealed class UserModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder group)
        {
            var app = group.MapGroup("/users").WithTags("Users");


        }
    }
}
