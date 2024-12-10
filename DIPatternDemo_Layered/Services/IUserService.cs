using DIPatternDemo_Layered .Models;

namespace DIPatternDemo_Layered .Services
    {
    public interface IUserService
        {
        int Register ( User user );
        User ValidateUser ( User user );
        }
    }
