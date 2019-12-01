
using GAP.Transversal.Models;
using GAP.Transversal.Response;
using System.Collections.Generic;

namespace GAP.BussinesLogic.Contract
{
    public interface IPatient
    {
        Response<Patients> CreatePatient(Patients patients);
        Response<Patients> FindByDni(Patients patients);
    }
}
