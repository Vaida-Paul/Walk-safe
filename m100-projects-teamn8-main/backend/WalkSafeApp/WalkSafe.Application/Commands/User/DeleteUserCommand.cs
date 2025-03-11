using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WalkSafe.Application.Commands.User
{
    public class DeleteUserCommand : IRequest<Result>
    {
        [Required] public Guid userID { get; set; }
        public DeleteUserCommand(Guid userID)
        {
            this.userID = userID;
        }
    }
}
