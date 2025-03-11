using CSharpFunctionalExtensions;
using MediatR;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Core.Interfaces;
using WalkSafe.Infrastructure.Repositories;

namespace WalkSafe.Application.Commands.GreenSpace
{
    internal class AddGreenSpaceHandler : IRequestHandler<AddGreenSpaceCommand, Result>
    {
        private readonly IGreenSpaceRepository _repo;
        public AddGreenSpaceHandler(IGreenSpaceRepository repo)
        {
            _repo = repo;
        }
        public async Task<Result> Handle(AddGreenSpaceCommand request, CancellationToken cancellationToken)
        {
            return await _repo.AddGreenSpaceAsync(request.Name, request.Description, request.Longitude, request.Latitude);
        }
    }
}
