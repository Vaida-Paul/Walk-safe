using Microsoft.EntityFrameworkCore;
using WalkSafe.Core.Entities.LandmarkAggregate;
using WalkSafe.Core.Interfaces;
using WalkSafe.Infrastructure.Context;

namespace WalkSafe.Infrastructure.Repositories
{
    public class LandmarkRepoistory : ILandmarkRepository
    {
        private readonly WalkSafeContext _context;
        public LandmarkRepoistory(WalkSafeContext context)
        {
            _context = context;
        }
        public async Task<bool> AddLandmarkAsync(Landmark landmark)
        {
            try
            {
                await _context.Landmarks.AddAsync(landmark);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add landmark.\n");
            }
        }

        public async Task<List<Landmark>> GetAllLandmarksAsync()
        {
            return await _context.Landmarks.ToListAsync();
        }

        public async Task<Landmark> GetLandmarkByIdAsync(Guid id)
        {
             return await _context.Landmarks.FindAsync(id);
        }

        public async Task<bool> RemoveLandmarkAsync(Guid id)
        {
            try
            {
                var landmark = await _context.Landmarks.FindAsync(id);
                if (landmark != null)
                {
                    _context.Landmarks.Remove(landmark);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to remove landmark.\n");
            }
        }
    }
}
