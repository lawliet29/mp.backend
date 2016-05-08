using Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Backend.Controllers
{
    public class AgroCultureController : ApiController
    {
        private readonly IAgroCultureService _service;
        public AgroCultureController(IAgroCultureService service)
        {
            _service = service;
        }

        [HttpGet, Route("agroCulture")]
        public IHttpActionResult List()
        {
            return Ok(_service.List());
        }

        [HttpGet, Route("agroCulture/{id}")]
        public IHttpActionResult GetByIdFullModel(int id)
        {
            var model = _service.GetByIdFullModel(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public IHttpActionResult GetByIdShort(int id)
        {
            var model = _service.GetByIdShort(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
