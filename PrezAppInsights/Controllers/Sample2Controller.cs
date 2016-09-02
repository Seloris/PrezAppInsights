using PrezAppInsights.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PrezAppInsights.Controllers
{
    [RoutePrefix("api/sample2")]
    public class Sample2Controller : ApiController
    {
        [Route("prompt")]
        [HttpPost]
        public HttpResponseMessage Prompt([FromBody] PromptRequestModel data)
        {
            // Would be a service call
            string result = ProcessPrompt(data);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        private string ProcessPrompt(PromptRequestModel data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            return $"You wrote : {data.Data}";
        }
    }
}