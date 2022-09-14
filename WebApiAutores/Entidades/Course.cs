using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Entidades
{
    public class Course
    {
        
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime beginDate { get; set; }

        public DateTime endDate { get; set; }

        public Char isActive { get; set; }

        //public string? ImgPath { get; set; }

        public List<Assistance> Assistance { get; set; }

        public List<Class> Classes { get; set; }

        internal bool Any()
        {
            throw new NotImplementedException();
        }
    }
}
