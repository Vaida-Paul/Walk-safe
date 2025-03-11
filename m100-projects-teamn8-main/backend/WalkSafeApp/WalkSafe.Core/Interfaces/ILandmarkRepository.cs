using WalkSafe.Core.Entities.LandmarkAggregate;

namespace WalkSafe.Core.Interfaces
{
    public interface ILandmarkRepository
    {
        public Task<bool> AddLandmarkAsync(Landmark landmark);
        public Task<bool> RemoveLandmarkAsync(Guid id);
        public Task<Landmark> GetLandmarkByIdAsync(Guid id);
        public Task<List<Landmark>> GetAllLandmarksAsync();
    }
}
