using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Repositories
{
    public class UserRepository
    {
        public User GetById(int Id)
        {
            User user;

            using (var dbContext = new AppContext())
            {
                user = dbContext.Users.FirstOrDefault(u => u.Id.Equals(Id));
            }

            return user;
        }

        public List<User> GetAll() 
        {
            List<User> users;

            using (var dbContext = new AppContext())
            {
                users = dbContext.Users.ToList();
            }

            return users;
        }
    }
}
