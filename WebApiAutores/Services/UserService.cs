using Microsoft.AspNetCore.Mvc;
using WebApiAutores.Entidades;
using WebApiAutores.Repositories;

namespace WebApiAutores.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            try
            {

                return _userRepository.GetAllUsers();

            }
            catch (Exception ex)

            {
                throw ex;

            }
          

        }

        public User GetById(int id)
        {
            try
            {

                var user = _userRepository.GetById(id);
                if (user != null)
                    return user;

                return null;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }

        public void DeleteUser(int id)
        {
            
        }

       
        
    }
}
