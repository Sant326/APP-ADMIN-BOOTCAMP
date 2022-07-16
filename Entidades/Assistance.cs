namespace WebApiAutores.Entidades
{
    public class Assistance
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }

        public int Order { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }

        public Course Course { get; set; }




    }
}
