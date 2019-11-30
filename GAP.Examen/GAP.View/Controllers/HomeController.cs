using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GAP.View.Models;
using RestSharp;
using GAP.Transversal.Models;

namespace GAP.View.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            //Dates date = new Dates();
            //date.Id = new Guid("215E642A-EDAD-4547-B40D-D4E16E8C62CE");
            //RestRequest request;
            //var client = new RestClient(); 

            //request = new RestRequest("https://localhost:44375/api/Dates/IsCancelable",Method.POST);
            //client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            //request.AddJsonBody(date);
            //IRestResponse result = client.Execute(request);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
