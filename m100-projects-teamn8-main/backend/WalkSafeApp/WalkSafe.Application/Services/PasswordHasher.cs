using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Application.Services.Interfaces;
using WalkSafe.Core.Entities.UserAggregate;

namespace WalkSafe.Application.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<UserAccount> _passwordHasher = new PasswordHasher<UserAccount>();

        public string Hash(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
