using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using WalkSafe.Core.Entities.GreenSpaceAggregate;
using WalkSafe.Core.Interfaces;
using WalkSafe.Infrastructure.Context;

namespace WalkSafe.Infrastructure.Repositories
{
    public class GreenSpaceRepository : IGreenSpaceRepository
    {
        private readonly WalkSafeContext _context;
        public GreenSpaceRepository(WalkSafeContext context)
        {
            _context = context;
        }
        public async Task<Result> AddGreenSpaceAsync(string name, string description, float longitude, float latitude)
        {
            var greenSpace = new GreenSpace(name, description, longitude, latitude);
            try
            {
                if (GetGreenSpaceByIdAsync(greenSpace.Id) == null)
                    return Result.Failure("Object already exists!\n");
                await _context.GreenSpaces.AddAsync(greenSpace);
                await _context.SaveChangesAsync();
                return Result.Success("Added object.\n");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.ToString());
            }
        }

        public async Task<List<GreenSpace>> GetAllGreenSpacesAsync()
        {
            return await _context.GreenSpaces.ToListAsync();
        }

        public async Task<GreenSpace> GetGreenSpaceByIdAsync(Guid id)
        {
            return await _context.GreenSpaces.FindAsync(id);
        }

        public async Task<Result> RemoveGreenSpaceAsync(Guid id)
        {
            try
            {
                var greenSpace = await _context.GreenSpaces.FindAsync(id);
                if (greenSpace != null)
                {
                    _context.GreenSpaces.Remove(greenSpace);
                    await _context.SaveChangesAsync();
                    return Result.Success("Removed object.\n");
                }
                return Result.Failure("Failed to remove object.\n");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.ToString());
            }
        }
    }
}
