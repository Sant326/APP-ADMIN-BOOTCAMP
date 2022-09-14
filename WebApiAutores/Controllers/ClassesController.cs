using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOS;
using WebApiAutores.Entidades;
using WebApiAutores.Services;

namespace WebApiAutores.Controllers
{
    [ApiController]// decoramos el controlador con este atributo que me pemritira hacer validac automaticas respecto a data recibida
    [Route("api/classes")]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly IMapper mapper;

        public ClassesController(IClassService classService, IMapper mapper)
        {
            _classService = classService;
            this.mapper = mapper;

        }


        [HttpPost]
        public async Task<ActionResult<Class>> PostClass(ClassCreacionDTO classe)
        {

            try
            {
                _classService.AddClass(classe);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(classe);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetAllClasses()
        {

            var classes = await _classService.GetAllClasses();
            if (classes == null)
            {
                return NotFound();
            }
            return Ok(classes);

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClassDTO>> GetClassById(int id)
        {

            try
            {

                var classe = _classService.GetClassById(id);

                if (classe == null)
                {
                    return NotFound();
                }

                return Ok(classe);


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    " Error retrieving data from dtabase ");

            }









        }


            [HttpGet("{Search}")]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetClassesByTitle(string Title)
        {
            try
            {
                var classesResult = await _classService.GetClassesByTitle(Title);

                if (classesResult.Any())
                {

                    return Ok(classesResult);
                }
                return NotFound();


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    " Error retrieving data from dtabase ");

            }




        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditClass(int id, ClassDTO classe)
        {
            //if (id != pet.ID)
            //{
            //    return BadRequest();
            //}

            try
            {
                _classService.EditClass(id, classe);

                var classToreturn = _classService.GetClassById(id);

                return Ok(classToreturn);

            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        [HttpGet("{Id:int}/course")]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetClassesByCourse(int Id)
        {

            try
            {

                var classesOfCourse = await _classService.GetClassesByCourse(Id);

                if (classesOfCourse == null)
                {
                    return NotFound();

                   
                }

                return Ok(classesOfCourse);


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   " Error retrieving data from dtabase ");


            }



        }


    }  
}
