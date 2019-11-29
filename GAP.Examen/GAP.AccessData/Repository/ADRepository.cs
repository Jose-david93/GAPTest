using GAP.AccessData.Contract;
using GAP.Transversal.Models;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
            throw new NotImplementedException();
        }

        //public IEnumerable<T> FindBy(QueryParameters<T> queryParameters)
        //{
        //    return Insight.ADInsight.DefaultCnn<T>("SELECT externalOrderId AS DisplayId,shippingMethod,Value,Taxes,Discounts, CONCAT(Cust.firstName,Cust.lastName) AS FirstName ,fullname,fullname,address1,city " +
        //                         "FROM Orders.OrderHD OrdHD " +
        //                         "INNER JOIN Retail.addresses Addr ON OrdHD.billingAddressId = Addr.addressId " +
        //                         "INNER JOIN Retail.Customers Cust ON OrdHD.customerId = Cust.customerId " +
        //                         "WHERE externalOrderId LIKE '%" + searchValue + "%' " +
        //                         "ORDER BY " + sortColumnName + " " + sortColumnDirection.ToUpper() + " " +
        //                         "OFFSET " + start + " ROWS " +
        //                         "FETCH NEXT " + length + " ROWS ONLY ");
        //}

        public int Update(T entity)
        {
            using (var con = Insight.ADInsight.DefaultCnn.OpenWithTransaction())
            {
                int Result = con.Execute("Update" + entity.GetType().Name, entity);
                con.Commit();
                return Result;
            }
        }
    }
}
