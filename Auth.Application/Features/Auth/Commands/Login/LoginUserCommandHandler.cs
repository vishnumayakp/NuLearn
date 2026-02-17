using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Application.Common.Reponse;
using Auth.Application.Interfaces.IRepository;
using Auth.Application.Interfaces.IService;
using MediatR;

namespace Auth.Application.Features.Auth.Commands.Login
{
    public class LoginUserCommandHandler:IRequestHandler<LoginUserCommand, ApiResponse<string>>
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordService _service;
        private readonly IJwtService _jwtService;

        public LoginUserCommandHandler(IUserRepository repo, IPasswordService passwordService, IJwtService jwtService)
        {
            _repo = repo;
            _service = passwordService;
            _jwtService = jwtService;
        }

        public async Task<ApiResponse<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUserByEmail(request.Email);
            if (user == null)
            {
                return new ApiResponse<string>
                {
                    StatusCode = 404,
                    Message = "Invalid",
                    ErrorMessage = "Inavalid Email"
                };
            }

            bool isPasswordValid = await _service.VerifyPassword(user.PasswordHash, request.Password);
            if (!isPasswordValid)
            {
                return new ApiResponse<string>
                {
                    StatusCode = 404,
                    Message = "Invalid",
                    ErrorMessage = "Invalid Password"
                };
            }

            if (!user.IsActive)
            {
                return new ApiResponse<string>
                {
                    StatusCode = 403,
                    Message = "InActive Account",
                    ErrorMessage = "Account is InActive"
                };
            }

            var token = await _jwtService.GenerateToken(user);

            return new ApiResponse<string>
            {
                Data = token,
                StatusCode = 200,
                Message = "User Successfully Logined",
                ErrorMessage = null
            };


        }
    }
}
