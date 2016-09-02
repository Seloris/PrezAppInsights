using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using PrezAppInsights.Models;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PrezAppInsights.Controllers
{

    [RoutePrefix("api/sample3")]
    public class Sample3Controller : ApiController
    {

        [Route("writeblob")]
        [HttpPost]
        public async Task<HttpResponseMessage> WriteBlobAsync([FromBody] PromptRequestModel data)
        {
            if (ModelState.IsValid)
            {
                // Would be a service call
                await WriteBlobImplementationAsync(data);

                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid body");
        }

        private async Task WriteBlobImplementationAsync(PromptRequestModel data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // Setup config and create container
            string cs = ConfigurationManager.ConnectionStrings["BlobStorageAccount"].ConnectionString;
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(cs);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer logContainer = cloudBlobClient.GetContainerReference("appinsightspres");
            await logContainer.CreateIfNotExistsAsync();

            // Upload the blob
            string blobName = Guid.NewGuid().ToString();
            CloudBlockBlob blockBlob = logContainer.GetBlockBlobReference(blobName);
            await blockBlob.UploadTextAsync(data.Data);
        }
    }
}