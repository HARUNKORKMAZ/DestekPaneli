using DestekPaneli.Application.Common.Models;
using DestekPaneli.Application.DTOs;
using DestekPaneli.Application.Interfaces.Repositories;
using DestekPaneli.Domain.Entities;
using DestekPaneli.Domain.Enums;
using DestekPaneli.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DestekPaneli.Persistence.Repositories
{
    public class TicketManager : ITicketService
    {
        private readonly ApplicationDbContext _context;
        public TicketManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BaseResponse<object>> CloseAsync(Guid ticketId, Guid userId, string userRole)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null)
                return BaseResponse<object>.Fail("Destek talebi bulunamadı", 404);

            if (userRole != "Admin")
                return BaseResponse<object>.Fail("Bu işlem için yetkini yok", 403);

            ticket.TicketStatus = TicketStatusEnum.Closed;
            await _context.SaveChangesAsync();

            return BaseResponse<object>.Success(null, "Destek talebi başarıyla kapatıldı", 200);
        }

        public async Task<BaseResponse<object>> CreateAsync(CreateTicketRequestDto request, Guid userId)
        {
            var priority = PriorityLevelEnum.FromName(request.Priority) ?? PriorityLevelEnum.Low;
            var ticket = new Ticket
            {
                Subject = request.Subject,
                Description = request.Description,
                Priority = priority,
                TicketStatus = TicketStatusEnum.Open,
                UserId = userId,
            };

            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return BaseResponse<object>.Success(null, "Destek Talebi başarıla oluturuldu");
        }

        public async Task<BaseResponse<List<TicketResponseDto>>> GetAllAsync(Guid userId, string userRole)
        {
            var query = _context.Tickets
                .Include(x => x.User)
                .AsQueryable();

            if (userRole != "Admin")
            {
                query = query.Where(t => t.UserId == userId);
            }

            var tickets = await query
                .Select(t => new TicketResponseDto(
                    t.Id,
                    t.Subject,
                    t.Description,
                    t.TicketStatus.Name,
                    t.Priority.Name,
                    t.UserId,
                    t.User.FullName,
                    t.CreatedAt
                    ))
                .ToListAsync();

            return BaseResponse<List<TicketResponseDto>>.Success(tickets);

        }
    }
}
