using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Application.Services.Interfaces;
using WalkSafe.Core.Entities.UserAggregate;
using WalkSafe.Core.Interfaces;

namespace WalkSafe.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IPasswordHasher passwordHasher;
        public AuthenticationService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.passwordHasher = passwordHasher;
        }
        public async Task<string> LoginAsync(string email, string password)
        {
            var users = await userRepository.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user == null || !passwordHasher.VerifyPassword(password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid password or email!\n");
            }
            return jwtTokenGenerator.GenerateToken(user);
        }

        public async Task LogoutAsync(Guid userId)
        {
            await Task.CompletedTask;
        }

        public async Task<string> RegisterAsync(string email, string name, string password)
        {
            var hashedPassword = passwordHasher.Hash(password);
            var user = new UserAccount(name, email, hashedPassword);
            await userRepository.AddUserAsync(email, name, hashedPassword);
            return jwtTokenGenerator.GenerateToken(user);
        }
    }
}
