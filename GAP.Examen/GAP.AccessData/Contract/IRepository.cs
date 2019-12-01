using GAP.Transversal.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GAP.AccessData.Contract
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void Delete(T entity, string id);
        bool Update(T entity);

        IList<T> Find(T entity, QueryParameters parameters);
        IList<T> Find(T entity);
        T IsExist(T entity);
    }
}
