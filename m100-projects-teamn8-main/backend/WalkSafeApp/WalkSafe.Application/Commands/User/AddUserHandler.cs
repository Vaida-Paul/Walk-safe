using CSharpFunctionalExtensions;
using MediatR;
using WalkSafe.Core.Interfaces;

namespace WalkSafe.Application.Commands.User
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        public AddUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.AddUserAsync(request.Email, request.Name, request.Password);
        }
    }
}
