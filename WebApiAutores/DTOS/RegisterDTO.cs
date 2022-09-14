using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.DTOS
{
    public class RegisterDTO
    {
        public string Name { get; set; }

        public string LastName { get; set; }



        public string Dni { get; set; }

        public int UserTypeId { get; set; }

        public Char isActive { get; set; }

       

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }

    }
}
