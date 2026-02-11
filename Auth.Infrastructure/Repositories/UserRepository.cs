using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Application.Interfaces;
using Auth.Application.Interfaces.IRepository;
using Auth.Domain.Entities;
using Auth.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExist(string email)
        {
            return await _context.Users.AnyAsync(u=>u.Email == email);
        }
    }
}
