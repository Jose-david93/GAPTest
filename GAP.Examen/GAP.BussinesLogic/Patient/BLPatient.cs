using GAP.AccessData.Repository;
using GAP.BussinesLogic.Contract;
using GAP.Transversal.Models;
using GAP.Transversal.Response;

namespace GAP.BussinesLogic.Patient
{
    public class BLPatient : IPatient
    {
        public Response<Patients> CreatePatient(Patients patients)
        {
            Response<Patients> response = new Response<Patients>();
            Patients Data =  new ADRepositoryPatient().Add(patients);
            if (Data == null)
            {
                response.Success = false;
                response.Message = "No se creo el Paciente";
            }
            else
            {
                response.Success = true;
                response.Data = Data;
            }
            return response;
        }

        public Response<Patients> FindByDni(Patients patients)
        {
            Response<Patients> response = new Response<Patients>();
            Patients Data = new ADRepositoryPatient().FindByDni(patients);

            if (Data == null)
            {
                response.Success = false;
                response.Message = "Paciente no encontrado";
            }
            else
            {
                response.Success = true;
                response.Data = Data;
            }
            return response;

        }
    }
}
