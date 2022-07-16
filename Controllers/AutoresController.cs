using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]// decoramos el controlador con este atributo que me pemritira hacer validac automaticas respecto a data recibida
    [Route("api/autores")]
    public class AutoresController: ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;

        }

        // accion que va a responder a la peticion a la ruta de api/autores 

        //retornar listado de autores 
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            /*return new List<Autor>()
            {
                new Autor()
                { Id = 1, Nombre =  "Santiago" },
                new Autor() 
                { Id = 2, Nombre =  "Claudia" }

            };
            */

            var autor = await _context.Autores.Include(x => x.Libros).ToListAsync();
            if (autor == null)
                return NotFound();

            return autor;

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            /*return new List<Autor>()
            {
                new Autor()
                { Id = 1, Nombre =  "Santiago" },
                new Autor() 
                { Id = 2, Nombre =  "Claudia" }

            };
            */

            var autor = await _context.Autores.Include(x => x.Libros).FirstOrDefaultAsync(x => x.Id == id);
            if (autor == null)
                return NotFound();

            return autor;

        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<Autor>> Get(string nombre)
        {
            /*return new List<Autor>()
            {
                new Autor()
                { Id = 1, Nombre =  "Santiago" },
                new Autor() 
                { Id = 2, Nombre =  "Claudia" }

            };
            */

            var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));
            if (autor == null)
                return NotFound();

            return autor;

        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            _context.Add(autor);

            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id)

        {

            var Exists = await _context.Autores.AnyAsync(x => x.Id == id);

            if (!Exists)
                return NotFound();
            if (autor.Id != id)
                return BadRequest(" el id del autor no coincide con el id de la url");


            _context.Update(autor);
            await _context.SaveChangesAsync();

            return Ok();
            /*
            _context.Add(autor);

            await _context.SaveChangesAsync();
            return Ok();
            */
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete( int id)

        {
            var Exists = await _context.Autores.AnyAsync(x => x.Id == id);

            if (!Exists)
                return NotFound();

            _context.Remove(new Autor { Id = id });
            await _context.SaveChangesAsync();


            return Ok();
            /*
            _context.Add(autor);

            await _context.SaveChangesAsync();
            return Ok();
            */
        }


    }
}
