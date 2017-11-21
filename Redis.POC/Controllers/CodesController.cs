using System.Net.Http;
using System.Web.Http;
using Entities;
using Services;

namespace Redis.POC.Controllers
{
    public class CodesController : BaseController
    {
        private readonly ICodesService _codesService;

        public CodesController(ICodesService codesService)
        {
            _codesService = codesService;
        }

        public HttpResponseMessage GetAll()
        {
            return Ok(_codesService.GetAllCodes());
        }

        public HttpResponseMessage Get(string id)
        {
            return Ok(_codesService.GetCodeById(id));
        }

        public HttpResponseMessage Put(CodesEntity codesEntity)
        {
            _codesService.UpdateCode(codesEntity);

            return Ok();
        }

        public HttpResponseMessage Delete(string id)
        {
            _codesService.DeleteCode(id);

            return Ok();
        }
    }
}