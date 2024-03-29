﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAP.BussinesLogic.Contract;
using GAP.Transversal.Models;
using GAP.Transversal.Response;
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
            Response<Patients> result = patient.CreatePatient(request);
            return Ok(result);
        }

        [Route("GetPatients")]
        [HttpPost]
        public ActionResult GetPatients(QueryParameters queryParameters)
        {
            Response<IList<Patients>> result = patient.GetPatients(queryParameters);
            return Ok(result);
        }

        [Route("FindByDni/{dni}")]
        [HttpGet]
        public ActionResult FindByDni(string dni)
        {
            Patients request = new Patients(dni);

            Response<Patients> result = patient.FindByDni(request);
            return Ok(result);
        }
    }
}
