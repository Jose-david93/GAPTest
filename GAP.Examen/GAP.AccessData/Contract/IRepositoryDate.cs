using GAP.Transversal.Models;
using System.Collections.Generic;

namespace GAP.AccessData.Contract
{
    public interface IRepositoryDate : IRepository<Dates>
    {
        IList<Dates> FindBy(QueryParameters<Dates> queryParameters);
        bool IsCancelable(Dates date);
        bool HavePatientDate(Dates date);
    }
}
