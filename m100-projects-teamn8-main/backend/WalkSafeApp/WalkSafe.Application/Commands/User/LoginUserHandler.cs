using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Application.Services.Interfaces;

namespace WalkSafe.Application.Commands.User
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, Result<string>>
    {
        private readonly IAuthenticationService _authenticationService;
        public LoginUserHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var token = await _authenticationService.LoginAsync(request.Email, request.Password);
            return Result.Success(token);
        }
    }
}
