﻿using GAP.BussinesLogic.Contract;
using GAP.Transversal.Models;
using GAP.Transversal.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace GAP.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesController : ControllerBase
    {
        private IDate idate;
        private IPatient ipatient;
        public DatesController(IDate _date, IPatient _patient)
        {
            idate = _date;
            ipatient = _patient;
        }

        [Route("CancelDate/{Id}")]
        [HttpGet]
        public ActionResult CancelDate(string Id)
        {
            Response<bool> result = idate.CancelDate(Id);
            return Ok(result);
        }

        [Route("CreateDate")]
        [HttpPost]
        public ActionResult CreateDate(Dates request)
        {
            if (request.IdPatientJs == null || request.IdPatientJs == "")
            {
                Patients patients = new Patients(request.Dni, request.FirstName, request.LastName);
                Response<Patients> resultPatients = ipatient.CreatePatient(patients);
                if (resultPatients.Success)
                    request.IdPatient = resultPatients.Data.Id;
                else
                    return Ok(resultPatients);
            }
            else
            {
                request.IdPatient = new Guid(request.IdPatientJs);
            }
            request.IdService = new Guid(request.IdServiceJs);
            Response<Dates> result = idate.CreateDate(request);
            return Ok(result);
        }

        [Route("GetServices")]
        [HttpGet]
        public ActionResult GetServices()
        {
            Response<IList<Transversal.Models.Services>> result = idate.GetServices();
            return Ok(result);
        }

        [Route("GetDates")]
        [HttpPost]
        public ActionResult GetDates(QueryParameters queryParameters)
        {
            Response<IList<Dates>> result = idate.GetDates(queryParameters);
            return Ok(result);
        }
    }
}
