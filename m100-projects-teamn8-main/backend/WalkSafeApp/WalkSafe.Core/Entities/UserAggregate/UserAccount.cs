using WalkSafe.Core.Entities.AbstractClasses;

namespace WalkSafe.Core.Entities.UserAggregate
{
    public class UserAccount : BaseClass
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        //public string Preferences { get; set; } = string.Empty;
        //public List<PointOfInterest> Bookmarks { get; set; } = new List<PointOfInterest>();

        public UserAccount(string name, string email, string password) : base()
        {
            Name = name;
            Email = email;
            Password = password;
            Role = UserRole.User;
        }
        public UserAccount(UserAccount user) : base()
        {
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            Role = UserRole.User;
            //Preferences = user.Preferences;
            //Bookmarks = user.Bookmarks;
        }
        public void ChangeUserRole(UserRole role)
        {
            Role = role;
        }
        public void AddPreferences(string preferences)
        {
            //Preferences = preferences;
        }
        //public void AddBookmarks(PointOfInterest pointOfInterest)
        //{
        //    //Bookmarks.Add(pointOfInterest);
        //}
    }
}
