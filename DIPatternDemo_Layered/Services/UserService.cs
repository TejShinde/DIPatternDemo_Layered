using DIPatternDemo_Layered .Data;
using DIPatternDemo_Layered .Models;
using DIPatternDemo_Layered .Repositories;

namespace DIPatternDemo_Layered .Services
    {
    public class UserService : IUserService
        {
        private readonly IUserRepository repo;

        public UserService ( IUserRepository repo )
            {
            this .repo = repo;
            }

        public int Register ( User user )
            {
            
            return repo .Register(user);
            }

        public User ValidateUser ( User user )
            {
            //  return _context .Users .FirstOrDefault(u => u .Email == email && u .Password == password);
            return repo .ValidateUser(user);
            }
        }
    }
