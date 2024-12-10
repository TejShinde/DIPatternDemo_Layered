using DIPatternDemo_Layered .Models;

namespace DIPatternDemo_Layered .Repositories
    {
    public interface IUserRepository
        {
        public int Register ( User user );
        public User ValidateUser ( User user );
    
        }
    }
