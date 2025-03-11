using CSharpFunctionalExtensions;
using WalkSafe.Core.Entities.UserAggregate;

namespace WalkSafe.Core.Interfaces
{
    public interface IUserRepository
    {
        public Task<Result> AddUserAsync(string email, string name, string password);
        public Task<Result> RemoveUserAsync(Guid id);
        public Task<UserAccount> FindUserByIdAsync(Guid id);
        public Task<List<UserAccount>> GetAllUsers();
    }
}
