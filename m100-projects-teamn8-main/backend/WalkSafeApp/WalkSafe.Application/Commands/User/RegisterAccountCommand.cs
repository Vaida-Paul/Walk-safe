using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkSafe.Application.Commands.User
{
    public class RegisterAccountCommand : IRequest<Result<string>>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }    
        [Required] 
        public string Password { get; set; }
        public RegisterAccountCommand(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;
        }
    }
}
