﻿using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

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
            List<Book> books = new List<Book>();

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

        public List<Book> GetBooks(int lowYear, int highYear, string genre)
        {
            List<Book> books = new List<Book>();

            using (var dbcontext = new AppContext())
            {
                books = dbcontext.Books.Include(b => b.Genre).Where(b => b.Genre.Name.Equals(genre)).Where(b => b.Year >= lowYear && b.Year <= highYear).ToList();
            }

            return books;
        }

        public int GetCountByAuthor(string author)
        {
            int countBook = 0;

            using (var dbcontext = new AppContext())
            {
                countBook = countBook = dbcontext.Books.Include(b => b.Author).Where(b => b.Author.FirstName.Equals(author)).Count();
            }

            return countBook;
        }
    }
}
