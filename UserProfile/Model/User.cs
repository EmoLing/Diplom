using UserProfile.Model.Enums;

namespace UserProfile.Model
{
    public abstract record User
    {
        public Guid Guid { get; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; }
        public string Email { get; set; }
        public UserTypes UserType { get; }

        public User(string login, string password, UserTypes userType)
        {
            Guid = Guid.NewGuid();
            Login = login;
            Password = password;
            UserType = userType;
            CreatedDate = DateTime.Now;
        }
    }
}
