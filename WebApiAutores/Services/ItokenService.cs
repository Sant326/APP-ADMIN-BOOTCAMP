using WebApiAutores.Entidades;

namespace WebApiAutores.Services
{
    public interface ItokenService
    {

        string CreateToken(User user);
    }
}
