using WebApiAutores.DTOS;
using WebApiAutores.Entidades;

namespace WebApiAutores.Services
{
    public interface ICourseService
    {
        public void AddCourse(CourseCreacionDTO course); //AddCourse

        public Task<IEnumerable<CourseDTO>> GetAllCourses();

        public Task<IEnumerable<CourseDTO>> GetCoursesByName(string Name);

        public CourseDTO GetCourseById(int Id);

      

        public Course EditCourse(int Id, CourseDTO course); //EditCourse


       




    }
}
