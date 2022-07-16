using Microsoft.AspNetCore.Mvc;
using WebApiAutores.Entidades;

namespace WebApiAutores.Services
{
    public interface IUserService
    {

        public List<User> GetAllUsers();

        public User GetById(int id);

        public void DeleteUser(int id);


    }
}
