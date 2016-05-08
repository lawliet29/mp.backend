using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Backend.Services;

namespace Backend.Controllers
{
    public class FieldController : ApiController
    {
        private readonly IFieldService _service;
        public FieldController(IFieldService service)
        {
            _service = service;
        }

        [HttpGet, Route("fields")]
        public IHttpActionResult List()
        {
            return Ok(_service.List());
        }

        [HttpGet, Route("fields/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var model = _service.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet, Route("fields/{id}/history")]
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
