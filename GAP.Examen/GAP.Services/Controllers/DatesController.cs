using GAP.BussinesLogic.Contract;
using GAP.Transversal.Models;
using Microsoft.AspNetCore.Mvc;

namespace GAP.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesController : ControllerBase
    {
        private IDate date;
        public DatesController(IDate _date)
        {
            date = _date;
        }

        [Route("CancelDate")]
        [HttpPost]
        public ActionResult CancelDate(Dates request)
        {
            Dates result = date.CancelDate(request);
            return Ok(result);
        }

        [Route("CreateDate")]
        [HttpPost]
        public ActionResult CreateDate(Dates request)
        {
            Dates result = date.CreateDate(request);
            return Ok(result);
        }
    }
}
