using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int UserId { get; set; }
        public int authorId { get; set; }
        public int genreId { get; set; }
        public User User { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
