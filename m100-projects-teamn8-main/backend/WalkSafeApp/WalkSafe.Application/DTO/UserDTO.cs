using WalkSafe.Core.Entities.UserAggregate;

namespace WalkSafe.Application.DTO
{
    public class UserDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public UserRole userRole { get; set; }
    }
}
