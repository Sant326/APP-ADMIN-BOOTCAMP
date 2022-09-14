using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using WebApiAutores.DTOS;

using WebApiAutores.Entidades;
using WebApiAutores.Services;

namespace WebApiAutores.Controllers
{

    [ApiController]// decoramos el controlador con este atributo que me pemritira hacer validac automaticas respecto a data recibida
    [Route("api/account")]
    public class AccountController: ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public readonly ItokenService _tokenService;

        public AccountController(ApplicationDbContext context , ItokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;

        }
            /*
            [HttpPost]
            public async Task<ActionResult> Post([FromBody] UserCreacionDTO UserCreacionDTO)
            {
               
               
                
                




            }
            */
            [HttpPost("login")]
            public  ActionResult<UserDTO> Login(LoginDTO login)
            {
         
              var user =  _context.Users.SingleOrDefault(x => x.UserName == login.UserName);

                if (user == null) return Unauthorized("invalid credentials");

                using var hmac = new HMACSHA512(user.PasswordSalt);

                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

                for ( int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] !=  user.PasswordHash[i])
                    {

                    return Unauthorized("invalid credentials");

                    };

                
                }
            var token = _tokenService.CreateToken(user);
            //aca voy a devolver un dto antes de devolver el usuariovars
            var userDto = new UserDTO()
            {
                UserName = login.UserName,
                Token = token
            };
                return Ok(userDto);

            }

            [HttpPost("Register")]
            public   ActionResult<UserDTO> Register(RegisterDTO user)
            {

            //var userQuery = _context.Users.SingleOrDefault(x => x.UserName == user.UserName);

            //if (userQuery == null) return NotFound("user was not found");


            if (userExists(user.UserName)) return BadRequest("the username already exists");


                using var hmac = new HMACSHA512();

                var newUser = new User
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Dni = user.Dni,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                    PasswordSalt = hmac.Key,
                    UserTypeId = user.UserTypeId,
                    IsActive = user.isActive,
                };

                _context.Users.Add(newUser);

                _context.SaveChanges();

                var token = _tokenService.CreateToken(newUser);

                
                //aca voy a devolver un dto antes de devolver el usuariovars
                var userDto = new UserDTO()
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    UserName = user.UserName,

                    Token = token
                };
                return Ok(userDto);



        }

            private bool userExists(string username)
            {
                
                return _context.Users.Any(u => u.UserName == username);


            }

        
     }

 }
