using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Redis.POC.Controllers
{
    public class BaseController : ApiController
    {
        public new HttpResponseMessage Ok<T>(T obj)
        {
            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }

        public HttpResponseMessage Created()
        {
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}