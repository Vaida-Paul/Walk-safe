using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Application.DTO;

namespace WalkSafe.Application.Querries.GreenSpace
{
    public class GetGSByIdQuery : IRequest<GreenSpaceDTO>
    {
        [Required] public Guid Id { get; set; }
        public GetGSByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
