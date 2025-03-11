using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkSafe.Core.Entities.UserAggregate;

namespace WalkSafe.Application.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserAccount user);
    }
}
