using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
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
                user = dbContext.Users
                    .FirstOrDefault(u => u.Id
                    .Equals(Id));
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

        public void AddUser(User user)
        {         
            using (var dbContext = new AppContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }

        public void Delete(User user)
        {
            using (var dbContext = new AppContext())
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        public void UpdateNameById(int id, string nameUpdate)
        {
            using (var dbContext = new AppContext())
            {
                var userUpdate = GetById(id);
                userUpdate.Name = nameUpdate;
                dbContext.Update(userUpdate);
                dbContext.SaveChanges();
            }
        }     

        public int? GetCountBook(string nameUser)
        {
            int? countBook = 0;

            using (var dbcontext = new AppContext())
            {
                countBook = dbcontext.Users
                    .Include(u=>u.Books)
                    .Where(u => u.Name
                    .Equals(nameUser))
                    .FirstOrDefault()?.Books.Count;
            }

            return countBook;
        }
    }
}
