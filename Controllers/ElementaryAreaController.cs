using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Backend.Services;

namespace Backend.Controllers
{
    public class ElementaryAreaController : ApiController
    {
        private readonly IElementaryAreaService _service;
        public ElementaryAreaController(IElementaryAreaService service)
        {
            _service = service;
        }

        [HttpGet, Route("elementaryAreas")]
        public IHttpActionResult List()
        {
            return Ok(_service.List());
        }

        [HttpGet, Route("elementaryAreas/{id}")]
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

        [HttpGet, Route("elementaryAreas/{id}/history")]
        public IHttpActionResult GetHistoryById(int id)
        {
            var model = _service.GetHistoryById(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet, Route("elementaryAreas/{id}/soilComposition")]
        public IHttpActionResult GetSoilCompositionById(int id)
        {
            var model = _service.GetElAreaSoilCompositionById(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }



    }
}
