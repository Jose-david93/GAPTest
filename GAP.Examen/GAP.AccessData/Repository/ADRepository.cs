using GAP.AccessData.Contract;
using GAP.Transversal.Models;
using Insight.Database;
using System.Collections.Generic;
using System.Linq;

namespace GAP.AccessData.Repository
{
    public class ADRepository<T> : IRepository<T>
    {
        public T Add(T entity)
        {
            using (var con = Insight.ADInsight.DefaultCnn.OpenWithTransaction())
            {
                con.Insert("Insert" + entity.GetType().Name, entity);
                con.Commit();
                return entity;
            }
        }

        public void Delete(T entity, string id)
        {
            using (var con = Insight.ADInsight.DefaultCnn.OpenWithTransaction())
            {
                con.ExecuteSql("DELETE FROM " + entity.GetType().Name + " WHERE id = "+ id);
                con.Commit();
            }
        }

        public IList<T> Find(T entity, QueryParameters parameters)
        {
            return Insight.
                ADInsight.
                DefaultCnn.
                Query<T>("Find"+entity.GetType().Name, parameters);
        }

        public IList<T> Find(T entity)
        {
            return Insight.
                ADInsight.
                DefaultCnn.
                Query<T>("Find" + entity.GetType().Name);
        }

        public bool Update(T entity)
        {
            using (var con = Insight.ADInsight.DefaultCnn.OpenWithTransaction())
            {
                int Result = con.Execute("Update" + entity.GetType().Name, entity);
                con.Commit();
                return Result > 0;
            }
        }
    }
}
