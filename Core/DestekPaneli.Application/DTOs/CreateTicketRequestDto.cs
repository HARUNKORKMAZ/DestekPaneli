namespace DestekPaneli.Application.DTOs
{
    public record CreateTicketRequestDto
    (
        string Subject,
        string Description,
        string Priority
    );
}
