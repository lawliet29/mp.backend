using System;
using System.Linq;
using Backend.Services;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    public class HttpGetAttribute : Attribute { }

    public class RouteAttribute : Attribute
    {
        private readonly string _path;

        public RouteAttribute(string path)
        {
            _path = path;
        }
    }

    public class ElementaryAreaController
    {
        public static string Ok(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        private readonly IElementaryAreaService _service;
        public ElementaryAreaController(IElementaryAreaService service)
        {
            _service = service;
        }

        [HttpGet, Route("elementaryAreas")]
        public string List()
        {
            return Ok(_service.LoadEverything().ToDictionary(kvp => kvp.Key, kvp => new
            {
                id = kvp.Value.CommonInfo.Id,
                name = kvp.Value.CommonInfo.Name,
                points = Enumerable.Empty<object>(),
                info = kvp.Value
            }));
        }

        [HttpGet, Route("elementaryAreas/{id}/history")]
        public string GetHistoryById(int id)
        {
            var model = _service.GetHistoryById(id);
            if (model == null)
            {
                return null;
            }

            return Ok(model);
        }

        [HttpGet, Route("elementaryAreas/{id}/soilComposition")]
        public string GetSoilCompositionById(int id)
        {
            var model = _service.GetElAreaSoilCompositionById(id);
            if (model == null)
            {
                return null;
            }

            return Ok(model);
        }



    }
}
