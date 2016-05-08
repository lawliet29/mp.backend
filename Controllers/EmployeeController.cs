using Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Backend.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet, Route("employee")]
        public IHttpActionResult List()
        {
            return Ok(_service.List());
        }

        [HttpGet, Route("employee/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var model = _service.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }


    }
}
