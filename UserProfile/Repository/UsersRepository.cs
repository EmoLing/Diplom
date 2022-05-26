using UserProfile.DbContexts;
using UserProfile.Model;
using UserProfile.ViewModel;

namespace UserProfile.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserContext _dbContext;
        public UsersRepository(UserContext userContext)
        {
            _dbContext = userContext;
        }

        public void CreateUser(User user)
        {
            if (_dbContext.Users.Any(u
                => u.Guid == user.Guid || u.Login == user.Login || u.Email == user.Email))
            {
                throw new Exception("Пользоователь с такими данными уже есть в системе");
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(Guid guid)
        {
            var user = _dbContext.Users.Find(guid);
            if (user is null)
                throw new Exception("Пользователь с данным GUID не найден");

            DeleteUserFromDb(user);
        }

        public void DeleteUser(User user)
        {
            var removingUser = _dbContext.Users.Find(user);
            if (removingUser is null)
                throw new Exception("Пользователь не найден");

            DeleteUserFromDb(user);
        }

        private void DeleteUserFromDb(User user)
        {
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetUsers() => _dbContext.Users.ToList();

        public void UpdateUser(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            var updatingUser = _dbContext.Users.FirstOrDefault(u => u.Guid == user.Guid);
            if (updatingUser is null)
                throw new Exception("Пользователь не найден");

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public User FindUser(UserViewModel userViewModel)
            =>_dbContext.Users.FirstOrDefault(u
                => u.Login == userViewModel.Login && u.Password == userViewModel.Password);
    }
}
