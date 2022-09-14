using WebApiAutores.DTOS;
using WebApiAutores.Entidades;
using WebApiAutores.Extensions;
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

        public async Task<IEnumerable<CourseDTO>> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllCourses();
            //return courses;
            var returnCourses = courses.Select(x => x.MapToCourseForListDto());
            return (IEnumerable<CourseDTO>)returnCourses;
            //var petsToReturn = _mapper.Map<IEnumerable<PetDTO>>(pets);
            //return petsToReturn;
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByName(string Name)
        {
            try
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    var courses = await _courseRepository.GetCoursesByName(Name);

                    return courses.Select(x => x.MapToCourseForListDto());

                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;

            }




        }

        public  CourseDTO GetCourseById(int id)
        {
            try
            {
                var course =  _courseRepository.GetCourseById(id);

                if (course == null)
                {
                    return null;
                }

                return course.MapToCourseForListDto();



            }
            catch(Exception ex)
            {

                throw ex;

            }
           
        }

        public Course EditCourse( int Id , CourseDTO coursedto)
        {
            try
            {
                var oldCourse = _courseRepository.GetCourseById(Id);
                if (oldCourse != null)
                {
                    oldCourse.Name = coursedto.Name;
                    oldCourse.Description = coursedto.Description;
                    oldCourse.beginDate = coursedto.beginDate;
                    oldCourse.endDate = coursedto.endDate;
                  
                    
                   
                        return _courseRepository.EditCourse(oldCourse);
                   
                    
                    
                       
                    
                }
                return null;


            }
            catch ( Exception ex)
            {
                throw ex;

            }

        }
    }
}
