using BookLibrary.Configurations;
using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class AppContext: DbContext
    {        
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);            
        }
    }
}
