using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Interfaces.IService
{
    public interface IPasswordService
    {
        Task<string> HashPassword(string password);
        Task<bool> VerifyPassword(string hashedPassword, string providedPassword);
    }
}
