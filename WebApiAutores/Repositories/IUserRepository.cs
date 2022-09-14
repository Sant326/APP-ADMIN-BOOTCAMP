using Microsoft.AspNetCore.Mvc;
using WebApiAutores.Entidades;

namespace WebApiAutores.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();

        public User GetById(int id);

        public void DeleteUser(int id);





    }
}
