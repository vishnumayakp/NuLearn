using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Application.Common.Reponse;
using Auth.Application.Interfaces.IRepository;
using Auth.Application.Interfaces.IService;
using Auth.Domain.Entities;
using MediatR;

namespace Auth.Application.Features.Auth.Commands.Register
{
    public class RegisterUserHandler:IRequestHandler<RegisterUserCommand, ApiResponse<Guid>>
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordService _passwordService;
        public RegisterUserHandler(IUserRepository repo, IPasswordService password)
        {
            _repo = repo;
            _passwordService = password;
        }

        public async Task<ApiResponse<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var exist = await _repo.EmailExist(request.Email);
            if (exist)
            {
                throw new Exception("Email Already Exist");
            }

            var password = await _passwordService.HashPassword(request.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                PasswordHash = password,
                IsActive = true,
                IsEmailVerified = true,
                EmailVerificationToken = Guid.NewGuid().ToString(),
                EmailVerificationTokenExpiry = DateTime.UtcNow.AddHours(24),
                RefreshToken = null,
                RefreshTokenExpiry = null,
                Created_At = DateTime.UtcNow,
                Role = Roles.Student,

            };

            await _repo.AddUser(user);

            return new ApiResponse<Guid>
            {
                Data = user.Id,
                StatusCode = 200,
                Message = "User Registered Successfully"
            };

        }
    }
}
