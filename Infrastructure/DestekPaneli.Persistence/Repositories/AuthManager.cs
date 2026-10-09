using DestekPaneli.Application.DTOs;
using DestekPaneli.Application.Interfaces.Repositories;
using DestekPaneli.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DestekPaneli.Persistence.Repositories
{
    public class AuthManager : IAuthService
    {
        private readonly ApplicationDbContext _context;
        public AuthManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> LoginAsync(LoginRequestDto request)
        {
            var existingUser = await _context.Users.AnyAsync(x => x.Email == request.Email);
            if (existingUser)
            {
                this new 
            }
        }

        public Task RegisterAsync(RegisterRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
