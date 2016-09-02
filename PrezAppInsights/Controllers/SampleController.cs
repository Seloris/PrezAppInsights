using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PrezAppInsights.Controllers
{
    [RoutePrefix("api/sample")]
    public class SampleController : ApiController
    {
        private static Random _rnd = new Random();

        // GET sample/hello
        [Route("hello")]
        [HttpGet]
        public async Task<string> HelloAsync()
        {
            await Task.Delay(_rnd.Next(100, 500));
            return "Hello Strasbourg";
        }

        [Route("increment")]
        [HttpPost]
        public HttpResponseMessage IncrementCount([FromBody] int count)
        {

        }
    }
}
