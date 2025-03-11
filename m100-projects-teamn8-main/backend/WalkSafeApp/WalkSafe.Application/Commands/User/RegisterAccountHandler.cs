using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Application.Services.Interfaces;

namespace WalkSafe.Application.Commands.User
{
    public class RegisterAccountHandler : IRequestHandler<RegisterAccountCommand, Result<string>>
    {
        private readonly IAuthenticationService _authenticationService;
        public RegisterAccountHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<Result<string>> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var token = await _authenticationService.RegisterAsync(request.Email, request.Name, request.Password);
            return Result.Success(token);
        }
    }
}
