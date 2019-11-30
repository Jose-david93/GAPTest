
using GAP.Transversal.Models;
using System.Collections.Generic;

namespace GAP.BussinesLogic.Contract
{
    public interface IPatient
    {
        Patients CreatePatient(Patients patients);
        Patients FindByDni(Patients patients);
    }
}
