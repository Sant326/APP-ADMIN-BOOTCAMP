namespace WebApiAutores.Entidades
{
    public class Class
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        //public string? videoUrl { get; set; } = string.Empty;
        
        public int CourseId { get; set; }

        public Course Course { get; set; }

    }
}
