using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Application.Interfaces.IService;
using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Services
{
    public class PasswordService:IPasswordService
    {
        private readonly PasswordHasher<object> _passwordHasher;

        public PasswordService()
        {
            _passwordHasher = new PasswordHasher<object>();
        }
        public async Task<string> HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null!,password);
        }

        public async Task<bool> VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);

            return result==PasswordVerificationResult.Success;
        }
    }
}
