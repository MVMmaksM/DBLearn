using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Repositories
{
    public class BookRepository
    {
        public Book GetById(int Id)
        {
            Book book;

            using (var dbContext = new AppContext())
            {
                book = dbContext.Books.FirstOrDefault(b => b.Id.Equals(Id));
            }

            return book;
        }

        public List<Book> GetAll()
        {
            List<Book> books;

            using (var dbContext = new AppContext())
            {
                books = dbContext.Books.ToList();
            }

            return books;
        }

        public int Add(Book book)
        {
            int resultAdd = 0;

            using (var dbContext = new AppContext())
            {
                dbContext.Books.Add(book);
                resultAdd = dbContext.SaveChanges();
            }

            return resultAdd;
        }

        public void Delete(Book book)
        {
            using (var dbContext = new AppContext())
            {
                dbContext.Books.Remove(book);
                dbContext.SaveChanges();
            }
        }

        public void UpdateYearById(int id, int yearUpdate)
        {
            using (var dbContext = new AppContext())
            {
                var bookUpdate = GetById(id);
                bookUpdate.Year = yearUpdate;
                dbContext.SaveChanges();
            }
        }
    }
}
