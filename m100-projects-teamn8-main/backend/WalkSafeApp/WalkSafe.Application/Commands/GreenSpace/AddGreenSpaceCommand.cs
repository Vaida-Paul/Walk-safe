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
    public class AddGreenSpaceCommand : IRequest<Result>
    {
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public float Longitude { get; set; }
        [Required] public float Latitude { get; set; }

        public AddGreenSpaceCommand(string name, string description, float longitude, float latitude)
        {
            Name = name;
            Description = description;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
