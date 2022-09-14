using AutoMapper;
using WebApiAutores.DTOS;
using WebApiAutores.Entidades;
using WebApiAutores.Extensions;
using WebApiAutores.Repositories;


namespace WebApiAutores.Services
{
    public class ClassService : IClassService
    {

        private readonly IClassRepository _classRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public ClassService(IClassRepository classRepository,ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _classRepository = classRepository;
            this._mapper = mapper;
        }
        public void AddClass(ClassCreacionDTO classes)
        {


            try
            {
                //var existeUsuarioConMismoUsername = await _context.Users.AnyAsync(x => x.UserName == UserCreacionDTO.UserName);

                //if (existeUsuarioConMismoUsername)
                //return BadRequest($" username already exists: {UserCreacionDTO.UserName}");
                //Course course = new Course()
                //{
                //    //Name = courseDto.Name,
                //    Name = courseDto.Name,
                //    Description = courseDto.Description,
                //    beginDate = courseDto.beginDate,
                //    endDate = courseDto.endDate,
                //    isActive = 'y'

                //};
                var classe = _mapper.Map<Class>(classes);
                _classRepository.AddClass(classe);
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }



        public async Task<IEnumerable<ClassDTO>> GetAllClasses()
        {


            var classes = await _classRepository.GetAllClasses();

            var classesToreturn = _mapper.Map<IEnumerable<ClassDTO>>(classes);
            return classesToreturn;





            //return courses;


            //var petsToReturn = _mapper.Map<IEnumerable<PetDTO>>(pets);
            //return petsToReturn;

        }

        public ClassDTO GetClassById(int Id)
        {



            try
            {
                var classe = _classRepository.GetClassById(Id);

                if (classe == null)
                {
                    return null;
                }

                var classeToReturn = _mapper.Map<ClassDTO>(classe);
                return classeToReturn;

                //return classe.MapToCourseForListDto();



            }
            catch (Exception ex)
            {

                throw ex;

            }





        }

        public async Task<IEnumerable<ClassDTO>> GetClassesByTitle(string Title)
        {

            try
            {
                if (!string.IsNullOrEmpty(Title))
                {
                    var classes = await _classRepository.GetClassessByTitle(Title);
                    var classesToReturn = _mapper.Map<IEnumerable<ClassDTO>>(classes);

                    return classesToReturn;

                    //return classes.Select(x => x.MapToCourseForListDto());

                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;

            }


        }


        public Class EditClass(int Id, ClassDTO classes)
        {
            try
            {
                var oldClass = _classRepository.GetClassById(Id);
                if (oldClass != null)
                {

                    oldClass.Title = classes.Title;
                    oldClass.Description = classes.Description;
                    oldClass.BeginDate = classes.BeginDate;
                    oldClass.EndDate = classes.EndDate;



                    return _classRepository.EditClass(oldClass);





                }
                return null;


            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<IEnumerable<ClassCreacionDTO>> GetClassesByCourse(int Id)
        {
            try
            {

                //var existsCourse =  _courseRepository.GetCourseById(Id);

                //if (existsCourse.Any())
                //{

                    var classesOfCourse = await _classRepository.GetClassesByCourse(Id);

                    if(classesOfCourse == null)
                    {

                        return null;


                     }



                    var classesOfCourseToR = _mapper.Map<IEnumerable<ClassCreacionDTO>>(classesOfCourse);
                    return classesOfCourseToR;


               // }

          





            }
            catch (Exception ex)
            {

                throw ex;

            }



        }
    }
}
