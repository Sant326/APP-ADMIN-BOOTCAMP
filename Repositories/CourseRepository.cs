using WebApiAutores.DTOS;
using WebApiAutores.Entidades;
using Microsoft.EntityFrameworkCore;

namespace WebApiAutores.Repositories


{
    public class CourseRepository: ICourseRepository    

    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public void AddCourse(Course course)
        {
            if (course != null)
            {
                try
                {
                    _context.Courses.Add(course);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}
