using DIPatternDemo_Layered .Models;
using DIPatternDemo_Layered .Data;

using System;

namespace DIPatternDemo_Layered .Repositories
    {
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext db;

        public UserRepository ( ApplicationDBContext db )
            {
            this.db = db;
            }

        public int Register ( User user )
            {
            //_context .Users .Add(user);
            //_context .SaveChanges();
            int result = 0;
            db.Users.Add( user );
            result = db .SaveChanges();
            return result;
            }

        public User Register ()
            {
            throw new NotImplementedException();
            }

        public User ValidateUser ( User user )
            {
            var res = (from u in db.Users
                       where u.Email == user.Email
                       && u.Password == user.Password
                       select u).FirstOrDefault();
            return res;
            }

        public User ValidateUser ()
            {
            throw new NotImplementedException();
            }

        //public User Login ( string username , string password )
        //    {
        //    return _context .Users .FirstOrDefault(u => u .UserName == username && u .Password == password);
        //    }

        //public bool IsUsernameAvailable ( string username )
        //    {
        //    return !_context .Users .Any(u => u .UserName == username);
        //    }
        }
    }
