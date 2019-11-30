using GAP.AccessData.Contract;
using GAP.Transversal.Models;
using Insight.Database;
using System.Collections.Generic;
using System.Linq;

namespace GAP.AccessData.Repository
{
    public class ADRepositoryDate : ADRepository<Dates>, IRepositoryDate
    {
        public IList<Dates> FindBy(QueryParameters<Dates> queryParameters)
        {
            return Insight.
                ADInsight.
                DefaultCnn.
                QuerySql<Dates>("SELECT  IdPatient,IdService,DataService,[Description],[Status] " +
                               "FROM Dates D " +
                               "INNER JOIN Patients P ON P.id = D.IdPatient "+
                               //"WHERE externalOrderId LIKE '%" + searchValue + "%' " +
                               "ORDER BY " + queryParameters.OrderBy + " " + queryParameters.OrderByDescending.ToUpper() + " " +
                               "OFFSET " + queryParameters.Page + " ROWS " +
                               "FETCH NEXT " + queryParameters.Top + " ROWS ONLY ");
        }

        public bool HavePatientDate(Dates date)
        {
            Dates result= Insight.
                            ADInsight.
                            DefaultCnn.
                            Query<Dates>("SELECT Id " +
                            "FROM Dates " +
                            "WHERE IdPatient = @IdPatient AND CONVERT(VARCHAR,DateService,111) = @DateService", 
                            new { IdPatient = date.IdPatient, DateService = date.DateService.ToString("yyyy/mm/dd") }).FirstOrDefault();
            if (result != null)
                return true;
            return false;
        }

        public bool IsCancelable(Dates date)
        {
            Dates result = Insight.
                            ADInsight.
                            DefaultCnn.
                            QuerySql<Dates>("SELECT Id " +
                            "FROM Dates " +
                            "WHERE Id = @Id AND DateService = DATEADD(day, -1 , GETDATE());"
                            , new { Id = date.Id }).FirstOrDefault();
            if (result == null)
                return true;
            return false;
        }
    }
}
