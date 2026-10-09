namespace DestekPaneli.Application.DTOs
{
    public record TicketResponseDto(
        Guid Id,
        string Subject,
        string Description,
        string TicketStatus,
        string Priority,
        Guid UserId,
        string FullName,
        DateTimeOffset CreatedAt
        );

}
