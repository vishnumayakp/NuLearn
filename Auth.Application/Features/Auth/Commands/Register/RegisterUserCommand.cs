using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Application.Common.Reponse;
using MediatR;

namespace Auth.Application.Features.Auth.Commands.Register
{
    public record RegisterUserCommand(
        string Name,
        string Email,
        string Password
        ): IRequest<ApiResponse<Guid>> ;
}
