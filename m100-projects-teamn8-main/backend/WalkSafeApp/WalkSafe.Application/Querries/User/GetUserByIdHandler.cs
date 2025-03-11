using MediatR;
using WalkSafe.Application.DTO;
using WalkSafe.Core.Interfaces;

namespace WalkSafe.Application.Querries.User
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuerry, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDTO> Handle(GetUserByIdQuerry request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindUserByIdAsync(request.userId);
            var userDto = new UserDTO
            {
                id = user.Id,
                name = user.Name,
                email = user.Email,
                password = user.Password,
                userRole = user.Role,
            };
            return userDto;
        }
    }
}
