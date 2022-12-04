using BookStore2.Models;
using BookStore2.Models.Repositiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorstore2.Models.Repositiories
{
    public class AuthorDbRepository : IBookStoreRepository<Authors>
    {

        BookStoryDbContext authorsdb;
        public AuthorDbRepository(BookStoryDbContext _db)
        {
            authorsdb = _db;
        }
        public void add(Authors entity)
        {
            authorsdb.authors.Add(entity);
            authorsdb.SaveChanges();
        }

        public void delete(int id)
        {
            authorsdb.authors.Remove(this.find(id));
            authorsdb.SaveChanges();
        }

        public void edit(int id , Authors entity)
        {

            authorsdb.Update(entity);
            authorsdb.SaveChanges();
        }

        public Authors find(int id)
        {
            return authorsdb.authors.SingleOrDefault(b => b.id == id);
        }

        public IList<Authors> list()
        {
            return authorsdb.authors.ToList();
        }
    }
}
