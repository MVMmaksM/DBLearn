using BookLibrary.Models;

namespace BookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new AppContext())
            {
                var user = new User { Name = "Maks", Email = "vaganov.maksim@mail.ru" };
                var user1 = new User { Name = "Ivan", Email = "vaganov.maksim@mail.ru" };

                var oneAuthor = new Author { FirstName = "Александр", LastName = "Птушкин", BirthDay = "21/12/2023" };
                var twoAuthor = new Author { FirstName = "Иван", LastName = "Творгенин", BirthDay = "05/12/1685" };

                var oneGenre = new Genre {Name = "Рассказы" };
                var twoGenre = new Genre {Name = "Стихи" };

                dbContext.Users.Add(user);
                dbContext.Users.Add(user1);
                
                dbContext.SaveChanges();
            }
        }
    }
}