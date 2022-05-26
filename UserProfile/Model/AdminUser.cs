using UserProfile.Model.Enums;

namespace UserProfile.Model
{
    public record AdminUser : User
    {
        public AdminUser(string login, string password)
            : base(login, password, UserTypes.Admin) 
        { }

        #region Singleton
        private static AdminUser adminUser;

        public static AdminUser GetInstance(string login, string password)
            => adminUser ??= new AdminUser(login, password);
        #endregion
    }
}
