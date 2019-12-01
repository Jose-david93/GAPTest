using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAP.View.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}