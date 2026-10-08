using Carter;

namespace DestekPaneli.WebAPI.Modules
{
    public sealed class TicketModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder group)
        {
            var app = group.MapGroup("/tickets").WithTags("Tickets");
        }
    }
}
