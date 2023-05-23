using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookLibrary.Repositories
{
    public class BookRepository
    {
        public Book GetById(int Id)
        {
            Book book = new Book();

            using (var dbContext = new AppContext())
            {
                book = dbContext.Books.FirstOrDefault(b => b.Id.Equals(Id));
            }

            return book;
        }

        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();

            using (var dbContext = new AppContext())
            {
                books = dbContext.Books.ToList();
            }

            return books;
        }

        public void Add(Book book)
        {
            using (var dbContext = new AppContext())
            {
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
            }
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
                dbContext.Update(bookUpdate);
                dbContext.SaveChanges();
            }
        }

        public List<Book> GetBooks(int lowYear, int highYear, string genre)
        {
            List<Book> books = new List<Book>();

            using (var dbcontext = new AppContext())
            {
                var idGenre = dbcontext.Genres.FirstOrDefault(g => g.Name.Equals(genre)).Id;

                books = dbcontext.Books
                    .Where(b => b.GenreId
                    .Equals(idGenre) && (b.Year >= lowYear && b.Year <= highYear))
                    .ToList();
            }

            return books;
        }

        public int GetCountByAuthor(string lastNameAuthor)
        {
            int countBook = 0;

            using (var dbcontext = new AppContext())
            {
                countBook = dbcontext.Books.Include(b => b.Author).Where(b => b.Author.LastName.Equals(lastNameAuthor)).Count();
            }

            return countBook;
        }

        public int GetCountByGenre(string genre)
        {
            int countBook = 0;

            using (var dbcontext = new AppContext())
            {
                var idGenre = dbcontext.Genres
                    .FirstOrDefault(g => g.Name
                    .Equals(genre))?.Id;

                countBook = dbcontext.Books
                    .Where(b => b.GenreId
                    .Equals(idGenre))
                    .Count();
            }

            return countBook;
        }

        public bool IsEqualBook(string lastNameAuthor, string titleBook)
        {
            bool isEqualBook = false;

            using (var dbcontext = new AppContext())
            {
                var idAuthor = dbcontext.Authors
                    .FirstOrDefault(a => a.LastName
                    .Equals(lastNameAuthor))?.Id;

                isEqualBook = dbcontext.Books.Where(b => b.AuthorId.Equals(idAuthor) && b.Title.Equals(titleBook)).Count() > 0;                
            }

            return isEqualBook;
        }

        public Book GetMaxYearBook()
        {
            Book book = new Book();

            using (var dbcontext = new AppContext())
            {
                var maxYear = dbcontext.Books.Max(b => b.Year);
                book = dbcontext.Books.Where(b => b.Year == maxYear).FirstOrDefault();
            }

            return book;
        }

        public List<Book> GetAllAscTitle()
        {
            List<Book> books = new List<Book>();

            using (var dbcontext = new AppContext())
            {
                books = dbcontext.Books.OrderBy(b => b.Title).ToList();
            }

            return books;
        }

        public List<Book> GetAllDescYear()
        {
            List<Book> books = new List<Book>();

            using (var dbcontext = new AppContext())
            {
                books = dbcontext.Books.OrderByDescending(b => b.Year).ToList();
            }

            return books;
        }

        public bool IsEqualBook(string titleBook)
        {
            bool isEqualBook = false;

            using (var dbcontext = new AppContext())
            {
                isEqualBook = dbcontext.Books.Where(b => b.Title == titleBook && b.UserId != null).Count() > 0;
            }

            return isEqualBook;
        }
    }
}
