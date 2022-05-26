using Helper.Users.ViewModels;
using UserProfile.Model;

namespace UserProfile.Repository
{
    public interface IUsersRepository
    {
        public void CreateUser(User user);
        public void UpdateUser(Guid guid);
        public void UpdateUser(User user);
        public void DeleteUser(Guid guid);
        public void DeleteUser(User user);
        public IEnumerable<User> GetUsers();
        public User FindUser(UserViewModel userViewModel);
    }
}
