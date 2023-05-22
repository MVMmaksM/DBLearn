using BookLibrary.Models;

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

                //var book = new Book { Title = "Война и мир", Year = 1985 };
                //var book2 = new Book { Title = "Идиот", Year = 1865 };

                //dbContext.Users.Add(user);
                //dbContext.Users.Add(user1);
                //dbContext.Books.Add(book);
                //dbContext.Books.Add(book2);

                //dbContext.SaveChanges();

                var a = dbContext.Books.ToList();
            }
        }
    }
}