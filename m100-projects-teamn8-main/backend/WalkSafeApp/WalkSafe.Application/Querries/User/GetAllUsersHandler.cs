using MediatR;
using WalkSafe.Application.DTO;
using WalkSafe.Core.Interfaces;

namespace WalkSafe.Application.Querries.User
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsers();
            return users.Select(ua => new UserDTO
            {
                id = ua.Id,
                name = ua.Name,
                email = ua.Email,
                password = ua.Password,
                userRole = ua.Role,
            }).ToList();
        }
    }
}
