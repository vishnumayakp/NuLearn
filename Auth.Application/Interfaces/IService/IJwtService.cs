using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Domain.Entities;

namespace Auth.Application.Interfaces.IService
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user);
    }
}
