using GAP.AccessData.Contract;
using GAP.Transversal.Models;
using Insight.Database;
using System;
using System.Collections.Generic;

namespace GAP.AccessData.Repository
{
    public class ADRepositoryDate : ADRepository<Dates>, IRepositoryDate
    {
        public IList<Dates> FindBy(QueryParameters<Dates> queryParameters)
        {
            return Insight.
                ADInsight.
                DefaultCnn.
                QuerySql<Dates>(" SELECT  IdPatient,IdService,DataService,[Description],[Status]" +
                               "FROM Dates D " +
                               "INNER JOIN Patients P ON P.id = D.IdPatient"+
                               //"WHERE externalOrderId LIKE '%" + searchValue + "%' " +
                               "ORDER BY " + queryParameters.OrderBy + " " + queryParameters.OrderByDescending.ToUpper() + " " +
                               "OFFSET " + queryParameters.Page + " ROWS " +
                               "FETCH NEXT " + queryParameters.Top + " ROWS ONLY ");
        }
    }
}
