using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace PrezAppInsights.Controllers
{
    [RoutePrefix("api/sample1")]
    public class Sample1Controller : ApiController
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
    }
}
