using GAP.AccessData.Repository;
using GAP.BussinesLogic.Contract;
using GAP.Transversal.Models;
using GAP.Transversal.Response;
using System.Collections.Generic;

namespace GAP.BussinesLogic.Date
{
    public class BLDate : IDate
    {
        public Response<bool> CancelDate(string Id)
        {
            Response<bool> response = new Response<bool>();
            bool data = false;
            Dates date = new Dates();
            if (Id == "")
            {
                response.Success = false;
                response.Message = "Id no permitido";
                return response;
            }

            date.Id = new System.Guid(Id);
            date.Status = false;

            if (IsCancelable(date))
            {
                data = new ADRepositoryDate().Update(date);
                if (!data)
                {
                    response.Success = false;
                    response.Message = "No se cancelo la cita, intente de nuevo mas tarde";
                    response.Data = data;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Cita cancelada con exito";
                    response.Data = data;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "La cita no se puede cancelar";
            }
            return response;
        }

        public Response<Dates> CreateDate(Dates date)
        {
            Response<Dates> response = new Response<Dates>();
            Dates data = new Dates();
            if (!HavePatientDate(date))
            {
                data = new ADRepositoryDate().Add(date);
                if (data == null)
                {
                    response.Success = false;
                    response.Message = "No se creo la cita, intente de nuevo mas tarde";
                    response.Data = data;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Cita creada con exito";
                    response.Data = data;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "El paciente ya tiene una cita";
            }
            return response;
        }

        public Response<IList<Dates>> GetDates(QueryParameters queryParameters)
        {
            Dates dates = new Dates();
            Response<IList<Dates>> response = new Response<IList<Dates>>();
            IList<Dates> data = new ADRepositoryDate().Find(dates,queryParameters);
            if (data.Count > 0)
            {
                response.Success = true;
                response.Data = data;
            }
            else
            {
                response.Success = false;
                response.Data = data;
            }
            return response;
        }

        public Response<IList<Services>> GetServices()
        {
            Services services = new Services();
            Response<IList<Services>> response = new Response<IList<Services>>();

            IList<Services> servicesList = new ADRepository<Services>().Find(services);
            if (servicesList != null)
            {
                response.Success = true;
                response.Data = servicesList;
            }
            else
            {
                response.Success = false;
                response.Message = "No se encontraron servicios";
            }
            return response;
        }

        public bool HavePatientDate(Dates date)
        {
            return new ADRepositoryDate().HavePatientDate(date);
        }

        public bool IsCancelable(Dates date)
        {
            return new ADRepositoryDate().IsCancelable(date);
        }
    }
}
