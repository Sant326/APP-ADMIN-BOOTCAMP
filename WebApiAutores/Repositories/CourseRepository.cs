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

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByName(string Name)

        {
            IQueryable<Course> courses = _context.Courses;

            return await courses.Where(c => c.Name.Contains(Name)).ToListAsync();
        }

        public  Course GetCourseById(int id)
        {

            return _context.Courses.FirstOrDefault(c => c.Id == id);

        }

        public  Course EditCourse(Course course)
        {
            try
            {
                 _context.Courses.Update(course);
                _context.SaveChanges();
                return course;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
           /*
            var courseFdb = await _context.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);
            
            if (courseFdb != null)
            {
                courseFdb.Name = course.Name;
                courseFdb.Description = course.Description;
                courseFdb.beginDate = course.beginDate;
                courseFdb.endDate = course.endDate;

                await _context.SaveChangesAsync();
                return courseFdb;


            }

            return null;
           */
        }
    }
}
