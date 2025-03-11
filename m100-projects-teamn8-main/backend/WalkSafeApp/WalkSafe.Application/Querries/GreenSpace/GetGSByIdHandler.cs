using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Application.DTO;
using WalkSafe.Core.Interfaces;
using WalkSafe.Infrastructure.Repositories;

namespace WalkSafe.Application.Querries.GreenSpace
{
    public class GetGSByIdHandler : IRequestHandler<GetGSByIdQuery, GreenSpaceDTO>
    {
        private readonly IGreenSpaceRepository _repository;
        public GetGSByIdHandler(IGreenSpaceRepository repository)
        {
            _repository = repository;
        }
        public async Task<GreenSpaceDTO> Handle(GetGSByIdQuery request, CancellationToken cancellationToken)
        {
            var greenSpace = await _repository.GetGreenSpaceByIdAsync(request.Id);
            var greenSpaceDto = new GreenSpaceDTO
            {
                id = greenSpace.Id,
                name = greenSpace.Name,
                longitude = greenSpace.Longitude,
                latitude = greenSpace.Latitude,
            };
            return greenSpaceDto;
        }
    }
}
