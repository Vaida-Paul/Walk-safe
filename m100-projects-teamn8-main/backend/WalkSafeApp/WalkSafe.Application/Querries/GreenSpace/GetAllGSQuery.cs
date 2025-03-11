using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Application.DTO;

namespace WalkSafe.Application.Querries.GreenSpace
{
    public class GetAllGSQuery : IRequest<List<GreenSpaceDTO>>
    {
        public GetAllGSQuery()
        {
            
        }
    }
}
