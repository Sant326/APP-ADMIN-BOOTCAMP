using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiAutores.DTOS;
using WebApiAutores.Entidades;
using WebApiAutores.Services;

namespace WebApiAutores.Controllers
{

    [ApiController]// decoramos el controlador con este atributo que me pemritira hacer validac automaticas respecto a data recibida
    [Route("api/courses")]
    public class CoursesController: ControllerBase
    {

        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        //[Authorize] 
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CourseCreacionDTO course)
        {
            
            try
            {
                _courseService.AddCourse(course);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(course);
        }
    }
}
