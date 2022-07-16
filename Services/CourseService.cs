using WebApiAutores.DTOS;
using WebApiAutores.Entidades;
using WebApiAutores.Repositories;

namespace WebApiAutores.Services
{
    public class CourseService: ICourseService

    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        public void AddCourse(CourseCreacionDTO courseDto)
        {
            try
            {
                //var existeUsuarioConMismoUsername = await _context.Users.AnyAsync(x => x.UserName == UserCreacionDTO.UserName);

                //if (existeUsuarioConMismoUsername)
                    //return BadRequest($" username already exists: {UserCreacionDTO.UserName}");
                Course course = new Course()
                {
                    //Name = courseDto.Name,
                    Name = courseDto.Name,
                    Description = courseDto.Description,
                    beginDate = courseDto.beginDate,
                    endDate = courseDto.endDate,
                    isActive = 'y'

                };
                _courseRepository.AddCourse(course);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
