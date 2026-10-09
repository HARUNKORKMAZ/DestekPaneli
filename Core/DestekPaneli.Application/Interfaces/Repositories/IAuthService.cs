using DestekPaneli.Application.Common.Models;
using DestekPaneli.Application.DTOs;

namespace DestekPaneli.Application.Interfaces.Repositories
{
    public interface IAuthService
    {
        Task<BaseResponse> RegisterAsync(RegisterRequestDto request);
        Task<BaseResponse<string>> LoginAsync(LoginRequestDto request);
    }
}
