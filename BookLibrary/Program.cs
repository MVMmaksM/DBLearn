using BookLibrary.Models;
using BookLibrary.Repositories;

namespace BookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new AppContext())
            {
                //var user = new User { Name = "Maks", Email = "vaganov.maksim@mail.ru" };
                //var user1 = new User { Name = "Ivan", Email = "vaganov.maksim@mail.ru" };

                //var oneAuthor = new Author { FirstName = "Александр", LastName = "Птушкин", BirthDay = "21/12/2023" };
                //var twoAuthor = new Author { FirstName = "Иван", LastName = "Творгенин", BirthDay = "05/12/1685" };

                //var oneGenre = new Genre { Name = "Рассказы" };
                //var twoGenre = new Genre { Name = "Стихи" };

                //var oneBook = new Book { Title = "Преступление и помилование", Year = 1898, User = user, Author = oneAuthor, Genre = oneGenre };
                //var twoBook = new Book { Title = "Собака на соломе", Year = 1578, User = user1, Author = twoAuthor, Genre = oneGenre };

                //dbContext.Users.Add(user);
                //dbContext.Users.Add(user1);

                //dbContext.Authors.Add(oneAuthor);
                //dbContext.Authors.Add(twoAuthor);

                //dbContext.Genres.Add(oneGenre);
                //dbContext.Genres.Add(twoGenre);

                //dbContext.Books.Add(oneBook);
                //dbContext.Books.Add(twoBook);

                //dbContext.SaveChanges();

                //var userRepository = new UserRepository();
                //userRepository.UpdateNameById(7, "Шмфтывалоо");

                var bookRepository = new BookRepository();
                //bookRepository.Add(oneBook);

                //var book = bookRepository.GetById(3);
                //Console.WriteLine(book?.Title);

                //var books = bookRepository.GetAll();

                //foreach (var b in books)
                //{
                //    Console.WriteLine(b.Title);
                //}

                //bookRepository.Delete(book);

                //bookRepository.UpdateYearById(4, 1956);

                //var books = bookRepository.GetBooks(1890, 2000, "Рассказы");

                //foreach (var book in books)
                //{
                //    Console.WriteLine(book.Title);
                //}

                //var res = bookRepository.GetCountByAuthor("Творгенин");
                //var res = bookRepository.GetCountByGenre("Рассказы");

                var isEqualBook = bookRepository.IsEqualBook("Птушкиtн", "Собака на соломе");
            }
        }
    }
}