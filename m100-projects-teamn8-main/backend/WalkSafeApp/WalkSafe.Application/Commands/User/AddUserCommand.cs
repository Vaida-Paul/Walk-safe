using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WalkSafe.Application.Commands.User
{
    public class AddUserCommand : IRequest<Result>
    {
        [Required] public string Email { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Password { get; set; }

        public AddUserCommand(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;
        }
    }
}
