using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.DTOS
{
    public class CourseCreacionDTO
    {

        public int Id { get; set; }
        
           
        
        [Required]
        public  string Name
        {
            get; set;
        }
        public string? Description
        {
            get; set;
        }
        public DateTime beginDate
        {
            get; set;
        }
        public DateTime endDate
        {
            get; set;
        } 



    }
}
