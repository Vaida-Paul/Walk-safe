using CSharpFunctionalExtensions;
using MediatR;
using WalkSafe.Core.Interfaces;

namespace WalkSafe.Application.Commands.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.RemoveUserAsync(request.userID);
        }
    }
}
