using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.DTOS
{
    public class CourseCreacionDTO
    {

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime beginDate { get; set; }

        public DateTime endDate { get; set; }

        public Char isActive { get; set; }



    }
}
