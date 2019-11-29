using GAP.Transversal.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GAP.AccessData.Contract
{
    interface IRepository<T>
    {
        T Add(T entity);
        void Delete(T entity, string id);
        int Update(T entity);
        //IEnumerable<T> FindBy(QueryParameters<T> queryParameters);
    }
}
