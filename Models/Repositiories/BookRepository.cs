using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.Models.Repositiories
{
    public class BookRepository : IBookStoreRepository<Books>
    {
        List<Books> books;
        public BookRepository()
        {
            books = new List<Books>() 
            {
                new Books{
                    id=1, title="book1" , description="descrition1",author=new Authors{id=1,fullName="author1"}
                },
                new Books{
                    id=2, title="book2" , description="descrition2",author=new Authors{id=1,fullName="author1"}
                },
                new Books{
                    id=3, title="book3" , description="descrition3",author=new Authors{id=2,fullName="author2"}
                },
                new Books{
                    id=4, title="book4" , description="descrition4",author=new Authors{id=3,fullName="author3"}
                }
            };
        }
        public void add(Books entity)
        {
            entity.id =  books.Max(b => b.id) + 1;
            books.Add(entity);
        }

        public void delete(int id)
        {
            books.Remove(this.find(id));
        }

        public void edit(int id , Books entity)
        {
            Books book = this.find(id);
            book.id = entity.id;
            book.title = entity.title;
            book.description = entity.description;
            book.author = entity.author;
        }

        public Books find(int id)
        {
            return books.SingleOrDefault(b => b.id == id);
        }

        public IList<Books> list()
        {
            return books;
        }
    }
}
