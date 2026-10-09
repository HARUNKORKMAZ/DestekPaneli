using DestekPaneli.Application.Common.Models;
using DestekPaneli.Application.DTOs;

namespace DestekPaneli.Application.Interfaces.Repositories
{
    public interface ITicketService
    {
        Task<BaseResponse<object>> CreateAsync(CreateTicketRequestDto request, Guid userId);
        Task<BaseResponse<List<TicketResponseDto>>> GetAllAsync(Guid userId, string userRole);
        Task<BaseResponse<object>> CloseAsync(Guid ticketId, Guid userId, string userRole);

    }
}
