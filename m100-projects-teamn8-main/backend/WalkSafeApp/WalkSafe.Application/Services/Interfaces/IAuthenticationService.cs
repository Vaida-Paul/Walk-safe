using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkSafe.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(string email, string password);
        Task LogoutAsync(Guid userId);
        Task<string> RegisterAsync(string email, string name, string password);
    }
}
