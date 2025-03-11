using CSharpFunctionalExtensions;
using WalkSafe.Core.Entities.UserAggregate;
using WalkSafe.Core.Interfaces;
using WalkSafe.Infrastructure.Context;

namespace WalkSafe.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WalkSafeContext _context;
        public UserRepository(WalkSafeContext context)
        {
            _context = context;
        }
        public async Task<Result> AddUserAsync(string email, string name, string password)
        {
            var user = new UserAccount(name, email, password);
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return Result.Success("User was added.\n");
            }
            catch (Exception ex) 
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<UserAccount> FindUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public Task<List<UserAccount>> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Task.FromResult(users);
        }

        public async Task<Result> RemoveUserAsync(Guid id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return Result.Success("Deleted user!\n");
                }
                return Result.Failure("User does not exist!");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
