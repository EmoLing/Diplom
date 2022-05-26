using UserProfile.Model.Enums;

namespace UserProfile.Model
{
    public record SimpleUser : User
    {
        public SimpleUser(string login, string password)
            : base(login, password, UserTypes.Simple)
        {
        }
    }
}
