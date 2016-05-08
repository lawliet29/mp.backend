using Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Backend.Controllers
{
    public class PaymentCropController : ApiController
    {
        private readonly IPaymentCropService _service;
        public PaymentCropController(IPaymentCropService service)
        {
            _service = service;
        }

        [HttpGet, Route("paymentCrop")]
        public IHttpActionResult List()
        {
            return Ok(_service.List());
        }

        [HttpGet, Route("paymentCrop/{id}")]
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

        public IHttpActionResult GetPaymentCropElementaryArea(int id)
        {
            var model = _service.GetPaymentCropElementaryArea(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }


    }
}
