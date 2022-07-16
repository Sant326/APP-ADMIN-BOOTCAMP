namespace WebApiAutores.Entidades
{
    public class UserType
    {

        public int Id { get; set; }

        public string userType { get; set; }

        public string description { get; set; }

        public List<User> Users { get; set; }

    }
}
