namespace DestekPaneli.Application.DTOs
{
    public record RegisterRequestDto(
        string FullName,
        string Email,
        string Password
        );

}
