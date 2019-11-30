
using GAP.Transversal.Models;
using System.Collections.Generic;

namespace GAP.BussinesLogic.Contract
{
    public interface IDate
    {
        bool IsCancelable(Dates date);
        bool HavePatientDate(Dates date);
        Dates CancelDate(Dates date);
        Dates CreateDate(Dates date);
        IList<Dates> GetDates(QueryParameters<Dates> queryParameters);
    }
}
