
using GAP.Transversal.Models;
using GAP.Transversal.Response;
using System.Collections.Generic;

namespace GAP.BussinesLogic.Contract
{
    public interface IDate
    {
        bool IsCancelable(Dates date);
        bool HavePatientDate(Dates date);
        Response<bool> CancelDate(string Id);
        Response<Dates> CreateDate(Dates date);
        Response<IList<Dates>> GetDates(QueryParameters queryParameters);
        Response<IList<Services>> GetServices();
    }
}
