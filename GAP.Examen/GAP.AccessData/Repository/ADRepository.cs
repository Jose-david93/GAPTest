using GAP.AccessData.Contract;
using GAP.Transversal.Models;
using Insight.Database;
using System.Collections.Generic;

namespace GAP.AccessData.Repository
{
    public class ADRepository<T> : IRepository<T>
    {
        public T Add(T entity)
        {
            using (var con = Insight.ADInsight.DefaultCnn.OpenWithTransaction())
            {
                con.Execute("Insert" + entity.GetType().Name, entity);
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

        public T Update(T entity)
        {
            using (var con = Insight.ADInsight.DefaultCnn.OpenWithTransaction())
            {
                con.Execute("Update" + entity.GetType().Name, entity);
                con.Commit();
                return entity;
            }
        }
    }
}
