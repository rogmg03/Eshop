using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebService.Controllers
{
   
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    [MyCorsPolicy]
    public class TestController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var resp = new HttpResponseMessage()
            {
                Content = new StringContent("GET: Test message")
            };
            resp.Headers.Add("X-Custom-Header", "hello");
            return resp;
        }
    }
}