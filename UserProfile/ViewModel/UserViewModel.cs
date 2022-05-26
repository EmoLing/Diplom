using Microsoft.AspNetCore.Identity;

namespace UserProfile.ViewModel
{
    //public class User : IdentityUser
    public class UserViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public UserViewModel(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
