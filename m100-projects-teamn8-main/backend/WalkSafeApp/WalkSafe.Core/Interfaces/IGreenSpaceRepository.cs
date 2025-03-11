using CSharpFunctionalExtensions;
using WalkSafe.Core.Entities.GreenSpaceAggregate;

namespace WalkSafe.Core.Interfaces
{
    public interface IGreenSpaceRepository
    {
        public Task<GreenSpace> GetGreenSpaceByIdAsync(Guid id);
        public Task<Result> AddGreenSpaceAsync(string name, string description, float longitude, float latitude);
        public Task<Result> RemoveGreenSpaceAsync(Guid id);
        public Task<List<GreenSpace>> GetAllGreenSpacesAsync();

    }
}
