using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Repositories
{
    
   
   public class UserRepository : IUserRepository
   {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        

        public  List<User> GetAllUsers()
        {
             

            return _context.Users.ToList();
        }

        public  User GetById(int id)
        {
            var user  =  _context.Users.Find(id);

            return user;
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

       

            
           
    }
    
}
