using MediatR;
using WalkSafe.Application.DTO;

namespace WalkSafe.Application.Querries.User
{
    public class GetAllUsersQuery : IRequest<List<UserDTO>>
    {
        public GetAllUsersQuery() { }
    }
}
