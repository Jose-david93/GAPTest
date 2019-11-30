using GAP.Transversal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.AccessData.Contract
{
    public interface IRepositoryPatient : IRepository<Patients>
    {
        Patients FindByDni(Patients patients);
    }
}
