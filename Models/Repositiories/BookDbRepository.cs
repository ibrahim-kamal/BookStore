using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.Models.Repositiories
{
    public class BookDbRepository : IBookStoreRepository<Books>
    {
        BookStoryDbContext db;
        public BookDbRepository(BookStoryDbContext _db)
        {
            db = _db;
        }
        public void add(Books entity)
        {
            Console.WriteLine(entity.ToString());
            db.books.Add(entity);
            db.SaveChanges();
        }

        public void delete(int id)
        {
            db.books.Remove(this.find(id));
            db.SaveChanges();
        }

        public void edit(int id , Books entity)
        {

            db.books.Update(entity);
            db.SaveChanges();
        }

        public Books find(int id)
        {
            return db.books.SingleOrDefault(b => b.id == id);
        }

        public IList<Books> list()
        {
            return db.books.Include(a  => a.author).ToList();
        }
    }
}
