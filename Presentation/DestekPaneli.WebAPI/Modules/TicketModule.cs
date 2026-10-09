using Carter;
using DestekPaneli.Application.DTOs;
using DestekPaneli.Application.Interfaces.Repositories;

namespace DestekPaneli.WebAPI.Modules
{
    public sealed class TicketModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder group)
        {
            var app = group.MapGroup("/tickets").WithTags("Tickets");

            app.MapPost("/" async (CreateTicketRequestDto request, ITicketService ticketService) =>
            {
                if(!Guid.TryParse)
            });
        }
    }
}
