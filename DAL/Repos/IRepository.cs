using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Repos
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T Get(int id);
        IEnumerable<T> Get(Expression<Func<T,bool>> expression);

        bool Add(T data);
        bool Update(T data);
        bool Delete(T data);

        void Save();
    }
}
