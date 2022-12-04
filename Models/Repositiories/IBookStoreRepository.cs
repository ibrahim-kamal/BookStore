using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.Models.Repositiories
{
    public interface IBookStoreRepository<TEntity>
    {
        IList<TEntity> list();
        TEntity find(int id);

        void add(TEntity entity);
        void edit(int id , TEntity entity);
        void delete(int id);

    }
}
