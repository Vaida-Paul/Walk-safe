using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Core.Interfaces;
using WalkSafe.Infrastructure.Repositories;

namespace WalkSafe.Application.Commands.GreenSpace
{
    public class RemoveGreenSpaceHandler : IRequestHandler<RemoveGreenSpaceCommand, Result>
    {
        private readonly IGreenSpaceRepository _repository;
        public RemoveGreenSpaceHandler(IGreenSpaceRepository repository)
        {
            _repository = repository;
        }
        public Task<Result> Handle(RemoveGreenSpaceCommand request, CancellationToken cancellationToken)
        {
            return _repository.RemoveGreenSpaceAsync(request.Id);
        }
    }
}
