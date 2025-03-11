using MediatR;
using System.ComponentModel.DataAnnotations;
using WalkSafe.Application.DTO;

namespace WalkSafe.Application.Querries.User
{
    public class GetUserByIdQuerry : IRequest<UserDTO>
    {
        [Required] public Guid userId { get; set; }
        public GetUserByIdQuerry(Guid id)
        {
            userId = id;
        }
    }
}
