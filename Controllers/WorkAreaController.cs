using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Backend.Services;

namespace Backend.Controllers
{
    public class WorkAreaController : ApiController
    {
        private readonly IWorkAreaService _service;
        public WorkAreaController(IWorkAreaService service)
        {
            _service = service;
        }

        [HttpGet, Route("workAreas")]
        public IHttpActionResult List()
        {
            return Ok(_service.List());
        }

        [HttpGet, Route("workAreas/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var model = _service.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet, Route("workAreas/{id}/history")]
        public IHttpActionResult GetHistoryById(int id)
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
