namespace WebApiAutores.Entidades
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string  LastName { get; set; }


        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Dni { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Linkedin { get; set; }

        public string Github { get; set; }

        public string Website { get; set; }

        public string Profession { get; set; }

        public string Company { get; set; }

        public string Biography { get; set; }

        public DateTime LastPasswordChange { get; set; }

        public DateTime  BirthDate { get; set; }

        public Char IsActive { get; set; }

        public int UserTypeId { get; set; }

        

        public UserType UserType { get; set; }

        public List<Assistance> Assistance { get; set; }
        //public object Extension { get; internal set; }
    }
}
