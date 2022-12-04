using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.Models
{
    public class BookStoryDbContext:DbContext
    {

        public BookStoryDbContext(DbContextOptions<BookStoryDbContext> options):base(options)
        {
            
        }

        public DbSet<Authors> authors { get; set; }
        public DbSet<Books> books { get; set; }
    }
}
