using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAP.BussinesLogic.Contract;
using GAP.Transversal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAP.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatient patient;
        public PatientsController(IPatient _patient)
        {
            patient = _patient;
        }

        [Route("CreatePatient")]
        [HttpPost]
        public ActionResult CreatePatient(Patients request)
        {
            Patients result = patient.CreatePatient(request);
            return Ok(result);
        }

        [Route("FindByDni")]
        [HttpPost]
        public ActionResult FindByDni(Patients request)
        {
            Patients result = patient.FindByDni(request);
            return Ok(result);
        }
    }
}
