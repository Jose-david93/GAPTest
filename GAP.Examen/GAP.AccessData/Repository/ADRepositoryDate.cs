using GAP.AccessData.Contract;
using GAP.Transversal.Models;
using Insight.Database;
using System.Collections.Generic;
using System.Linq;

namespace GAP.AccessData.Repository
{
    public class ADRepositoryDate : ADRepository<Dates>, IRepositoryDate
    {
        public bool HavePatientDate(Dates date)
        {
            Dates result= Insight.
                            ADInsight.
                            DefaultCnn.
                            Query<Dates>("HavePatientDate", 
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
                            Query<Dates>("IsCancelable", 
                            new { Id = date.Id }).FirstOrDefault();
            if (result == null)
                return true;
            return false;
        }
    }
}
