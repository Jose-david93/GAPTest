using GAP.Transversal.Models;
using System.Collections.Generic;

namespace GAP.AccessData.Contract
{
    public interface IRepositoryDate : IRepository<Dates>
    {
        bool IsCancelable(Dates date);
        bool HavePatientDate(Dates date);
    }
}
