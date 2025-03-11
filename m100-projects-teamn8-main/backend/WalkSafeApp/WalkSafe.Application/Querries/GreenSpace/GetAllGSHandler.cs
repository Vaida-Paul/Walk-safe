using MediatR;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Application.DTO;
using WalkSafe.Core.Interfaces;
using WalkSafe.Infrastructure.Repositories;

namespace WalkSafe.Application.Querries.GreenSpace
{
    public class GetAllGSHandler : IRequestHandler<GetAllGSQuery, List<GreenSpaceDTO>>
    {
        private readonly IGreenSpaceRepository _repository;
        public GetAllGSHandler(IGreenSpaceRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GreenSpaceDTO>> Handle(GetAllGSQuery request, CancellationToken cancellationToken)
        {
            var greenSpaces = await _repository.GetAllGreenSpacesAsync();
            return greenSpaces.Select(gs => new GreenSpaceDTO
            {
                id = gs.Id,
                name = gs.Name,
                description = gs.Description,
                longitude = gs.Longitude,
                latitude = gs.Latitude
            }).ToList();
        }
    }
}
