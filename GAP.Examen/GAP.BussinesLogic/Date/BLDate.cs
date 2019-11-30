using GAP.AccessData.Repository;
using GAP.BussinesLogic.Contract;
using GAP.Transversal.Models;
using System.Collections.Generic;

namespace GAP.BussinesLogic.Date
{
    public class BLDate : IDate
    {
        public Dates CancelDate(Dates date)
        {
            if(IsCancelable(date))
                return new ADRepositoryDate().Update(date);
            return default;
        }

        public Dates CreateDate(Dates date)
        {
            if(HavePatientDate(date))
                return new ADRepositoryDate().Add(date);
            return default;
        }

        public IList<Dates> GetDates(QueryParameters<Dates> queryParameters)
        {
            return new ADRepositoryDate().FindBy(queryParameters);
        }

        public bool HavePatientDate(Dates date)
        {
            return new ADRepositoryDate().HavePatientDate(date);
        }

        public bool IsCancelable(Dates date)
        {
            return new ADRepositoryDate().IsCancelable(date);
        }
    }
}
