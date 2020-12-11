namespace gustav_v2.entity
{
    public class User
    {
        public User(User user)
        {
            Name = user.Name;
            Surname = user.Surname;
            Phone = user.Phone;
            Password = user.Password;
        }

        public User(string name, string surname, string phone, string password)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Password = password;
        }

        public User()
        {
            Name = null;
            Surname = null;
            Phone = null;
            Password = null;
        }

        public int Id { get; set; }
        public string Name{ get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}