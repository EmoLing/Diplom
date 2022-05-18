namespace Diplom.Model
{
    public abstract class User
    {
        public Guid Guid { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
