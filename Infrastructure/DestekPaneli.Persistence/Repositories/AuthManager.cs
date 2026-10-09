using DestekPaneli.Application.Common.Models;
using DestekPaneli.Application.DTOs;
using DestekPaneli.Application.Interfaces.Repositories;
using DestekPaneli.Domain.Entities;
using DestekPaneli.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DestekPaneli.Persistence.Repositories
{
    public class AuthManager : IAuthService
    {
        private readonly ApplicationDbContext _context;
        public AuthManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BaseResponse<string>> LoginAsync(LoginRequestDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password);
            if (user == null)
                return BaseResponse<string>.Fail("Geçersiz email veya şifre.", 401);

            return BaseResponse<string>.Success("Giriş Başarılı.");
        }

        public async Task<BaseResponse<object>> RegisterAsync(RegisterRequestDto request)
        {
            var existingUser = await _context.Users.AnyAsync(x => x.Email == request.Email);
            if (existingUser)
            {
                return BaseResponse<object>.Fail("Bu email adresi ile zaten bir kayıt mevcut.");
            }
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password,
                Role = "User"
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return BaseResponse<object>.Success("Kayıt işlemi başarılıyla gerçekleşti.");
        }
    }
}
