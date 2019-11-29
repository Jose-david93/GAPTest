using GAP.Transversal.Models;
using System.Collections.Generic;

namespace GAP.AccessData.Contract
{
    interface IRepositoryDate : IRepository<Dates>
    {
        IList<Dates> FindBy(QueryParameters<Dates> queryParameters);
    }
}
