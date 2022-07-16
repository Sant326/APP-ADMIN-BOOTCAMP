using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOS;
using WebApiAutores.Entidades;


using WebApiAutores.Extensions;
using WebApiAutores.Services;

namespace WebApiAutores.Controllers
{


    [ApiController]// decoramos el controlador con este atributo que me pemritira hacer validac automaticas respecto a data recibida
    [Route("api/users")]
    public class UsersController: ControllerBase
    {


        //private readonly ApplicationDbContext _context;
        private readonly UserService _userService;


        public UsersController(UserService userService)
        {
          
            _userService = userService;

        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<User>> Get()
        {
            /*return new List<Autor>()
            {
                new Autor()
                { Id = 1, Nombre =  "Santiago" },
                new Autor() 
                { Id = 2, Nombre =  "Claudia" }

            };
            */

            //var users = 

            var users =  _userService.GetAllUsers();
            if (users == null)
                return NotFound();


           // return users;
            
               

            

            var usersDto = users.Select(users => users.MaptoUserDTO());

             return Ok(usersDto);



            

        }





        [HttpGet("{id:int}")]
        //[Authorize]
        public ActionResult<UserDTO> GetById(int id)
        {

            var user =  _userService.GetById(id);
            if (user == null)
                return NotFound();


            var usersDto = user.MaptoUserDTO();// permite mapear el  objeto d eusuario con el DTO

            return Ok(usersDto);
            //return await _context.Users.Include(y => y.UserType).FirstOrDefaultAsync(li => li.Id == id);

        }
        /*
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCreacionDTO UserCreacionDTO)
        {
            
            var existeUsuarioConMismoUsername = await _context.Users.AnyAsync(x => x.UserName == UserCreacionDTO.UserName);

            if (existeUsuarioConMismoUsername)
                return BadRequest($" username already exists: {UserCreacionDTO.UserName}");

            var user = new User()
            {
                Name = UserCreacionDTO.Name,
                LastName = UserCreacionDTO.LastName,
                UserName = UserCreacionDTO.UserName,
                Dni = UserCreacionDTO.Dni,
                UserTypeId = UserCreacionDTO.UserTypeId,
                IsActive = 'Y'
            };

            _context.Add(user);

            await _context.SaveChangesAsync();
            return Ok();


            
        }
        
        */
    }
}
