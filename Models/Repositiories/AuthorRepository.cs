using BookStore2.Models;
using BookStore2.Models.Repositiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorstore2.Models.Repositiories
{
    public class AuthorRepository : IBookStoreRepository<Authors>
    {
        List<Authors> authors;
        public AuthorRepository()
        {
            authors = new List<Authors>() 
            {
                new Authors{id=1,fullName="author1"}
                ,new Authors{id=2,fullName="author2"}
                 ,new Authors{id=3,fullName="author3"}
            };
        }
        public void add(Authors entity)
        {
            authors.Add(entity);
        }

        public void delete(int id)
        {
            authors.Remove(this.find(id));
        }

        public void edit(int id , Authors entity)
        {
            Authors authors = this.find(id);
            authors.id = entity.id;
            authors.fullName= entity.fullName;
        }

        public Authors find(int id)
        {
            return authors.SingleOrDefault(b => b.id == id);
        }

        public IList<Authors> list()
        {
            return authors;
        }
    }
}
