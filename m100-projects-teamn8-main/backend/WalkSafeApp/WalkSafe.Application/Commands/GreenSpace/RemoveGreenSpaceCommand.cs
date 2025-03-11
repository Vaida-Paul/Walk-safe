using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkSafe.Application.Commands.GreenSpace
{
    public class RemoveGreenSpaceCommand : IRequest<Result>
    {
        [Required] public Guid Id { get; set; }
        public RemoveGreenSpaceCommand(Guid id)
        {
            Id = id;
        }
    }
}
