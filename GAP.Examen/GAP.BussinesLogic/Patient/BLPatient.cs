using GAP.AccessData.Repository;
using GAP.BussinesLogic.Contract;
using GAP.Transversal.Models;

namespace GAP.BussinesLogic.Patient
{
    class BLPatient : IPatient
    {
        public Patients CreatePatient(Patients patients)
        {
            return new ADRepositoryPatient().Add(patients);
        }

        public Patients FindByDni(Patients patients)
        {
            return new ADRepositoryPatient().FindByDni(patients);
        }
    }
}
