using WebApiAutores.DTOS;
using WebApiAutores.Entidades;   

namespace WebApiAutores.Extensions
{
    public static class Extension
    {

        public static UserDTO MaptoUserDTO( this User user)// permite mapear el usuario con el dto del usuario
        {
            
            if (user != null)
             {
                return new UserDTO
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Dni = user.Dni,
                    UserTypeId = user.UserTypeId,
                    isActive = user.IsActive,
                   


                };
            
            
            }

            return null;


        }

        public static Course MapFromCourseForAddDto(this CourseCreacionDTO course)
        {
            if (course != null)
            {
                return new Course
                {
                    Name = course.Name,
                    Description = course.Description,
                    beginDate = course.beginDate,
                    endDate = course.endDate,
                    isActive = 'y'
                };
            }

            return null;
        }


        public static CourseDTO MapToCourseForListDto(this Course course)
        {
            if (course != null)
            {
                return new CourseDTO
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    beginDate = course.beginDate,
                    endDate = course.endDate

                };
            }

            return null;
        }


        public static Course MapFromCourseForEditDto(this CourseDTO course)
        {
            if (course != null)
            {
                return new Course
                {
                    Name = course.Name,
                    Description = course.Description,
                    beginDate = course.beginDate,
                    endDate = course.endDate,
                   // isActive = 'y'
                };
            }

            return null;
        }








    }
}
