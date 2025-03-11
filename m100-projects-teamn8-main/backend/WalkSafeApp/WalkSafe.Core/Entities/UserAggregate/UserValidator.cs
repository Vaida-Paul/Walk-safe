using System.Text.RegularExpressions;

namespace WalkSafe.Core.Entities.UserAggregate
{
    public class UserValidator
    {
        public UserValidator()
        {
        }
        public bool ValidateUser(UserAccount user)
        {
            if (!ValidateName(user.Name)) throw new UserException("Name not valid!\n");
            if (!ValidateEmail(user.Email)) throw new UserException("Email not vaild!\n");
            if (!ValidatePassword(user.Password)) throw new UserException("Password not valid!\n");
            return true;
        }

        private bool ValidateName(string name)
        {
            var regex = @"^[A-Z][a-z]+$";
            string[] words = name.Split(" ");
            foreach (string word in words)
            {
                if (word.Length < 3)
                {
                    return false;
                }
                else
                {
                    if (!Regex.IsMatch(word, regex)) { return false; }
                }
            }
            return true;
        }

        private bool ValidateEmail(string email)
        {
            var regex = @"^[a-zA-Z0-9.a-zA-Z0-9]+@[a-z]+.[a-z]{3}$";
            return Regex.IsMatch(email, regex);
        }
        private bool ValidatePassword(string password)
        {
            if (password.Length < 10) return false;
            var regex = @"^[a-zA-Z0-9]+$";
            return Regex.IsMatch(password, regex);
        }
    }
}
