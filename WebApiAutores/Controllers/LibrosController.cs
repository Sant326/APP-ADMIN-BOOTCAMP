using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{

    [ApiController]// decoramos el controlador con este atributo que me pemritira hacer validac automaticas respecto a data recibida
    [Route("api/libros")]
    public class LibrosController: ControllerBase

    {
        private readonly ApplicationDbContext context;
        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> GetById(int id)
        {
            return await context.Libros.Include(y => y.Autor).FirstOrDefaultAsync(li => li.Id == id);

        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {

            var existeAutor = await context.Autores.AnyAsync(x => x.Id == libro.AutorId);

            if (!existeAutor)
                return BadRequest($"no existe el autor de id: {libro.AutorId}");

            context.Add(libro);

            await context.SaveChangesAsync();
            return Ok();



        }

    }
}
