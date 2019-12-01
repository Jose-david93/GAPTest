using GAP.Transversal.Models;
using GAP.Transversal.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GAP.View.Controllers
{
    public class DatesController : Controller
    {
        // GET: Dates
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Dates()
        {
            return View();
        }

        [Authorize]
        public IActionResult GetDates()
        {
            Dates dates= new Dates();
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

            var start = Request.Form["start"].FirstOrDefault();

            var length = Request.Form["length"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;

            int skip = start != null ? Convert.ToInt32(start) : 0;

            RestRequest request;
            var client = new RestClient();
            QueryParameters queryParameters = new QueryParameters(skip, pageSize);
            request = new RestRequest("https://localhost:44375/api/Dates/GetDates", Method.POST);
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            request.AddJsonBody(queryParameters);
            IRestResponse<Response<IList<Dates>>> result = client.Execute<Response<IList<Dates>>>(request);

            int recordsTotal = result.Data.Data.Count;
            int recordsFilteredCount = result.Data.Data.Count;
            return Json(new { draw = draw, recordsFiltered = recordsFilteredCount, recordsTotal = recordsTotal, data = result.Data.Data });
        }
    }
}