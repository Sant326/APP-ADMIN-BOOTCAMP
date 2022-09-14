using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Repositories
{
    public class ClassRepository : IClassRepository
    {

        private readonly ApplicationDbContext _context;

        public ClassRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public void AddClass(Class classes)
        {
            if (classes != null)
            {
                try
                {
                    _context.Classes.Add(classes);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public Class EditClass(Class classes)
        {
            try
            {
                _context.Classes.Update(classes);
                _context.SaveChanges();
                return classes;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<IEnumerable<Class>> GetAllClasses()
        {

            return await _context.Classes.ToListAsync();


        }

        public Class GetClassById(int id)
        {
            return _context.Classes.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IEnumerable<Class>> GetClassessByTitle(string Title)
        {
            IQueryable<Class> classes = _context.Classes;

            return await classes.Where(c => c.Title.Contains(Title)).ToListAsync();
        }


        public async Task<IEnumerable<Class>> GetClassesByCourse(int Id)
        {
            try
            {
                var ExistsCourse = await _context.Courses.AnyAsync(c => c.Id == Id);
                if (!ExistsCourse)
                {
                    return null;

                }

                //IQueryable<Class> classes = _context.Classes;

                var classesOfCourse = await _context.Classes.Where(c => c.CourseId == Id).ToListAsync();

                return classesOfCourse;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }






    }
}
