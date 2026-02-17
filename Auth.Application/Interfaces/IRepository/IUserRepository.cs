using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Domain.Entities;

namespace Auth.Application.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<bool> EmailExist(string email);
        Task<User?> GetUserByEmail(string email);
    }
}
