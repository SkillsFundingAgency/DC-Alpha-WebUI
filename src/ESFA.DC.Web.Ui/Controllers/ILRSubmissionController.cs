using System;
using System.IO;
using System.Threading.Tasks;
using DC.Web.Ui.ClaimTypes;
using DC.Web.Ui.Extensions;
using DC.Web.Ui.Models;
using DC.Web.Ui.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace DC.Web.Ui.Controllers
{
    [Authorize(Policy = PolicyTypes.FileSubmission)]
    public class ILRSubmissionController : Controller
    {
        private IUkprnClaimsHandlerService _ukprnClaimsHandler;
        public ILRSubmissionController(IUkprnClaimsHandlerService ukprnClaimsHandler)
        {
            _ukprnClaimsHandler = ukprnClaimsHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(IFormFile file)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("connectionstring");
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("ilr-files");



            var correlationId = Guid.NewGuid();
            var model = new IlrSubmission()
            {
                CorrelationId = correlationId,
                ContainerReference = "ilr-files",
                Filename = $" {Path.GetFileNameWithoutExtension(file.FileName).AppendRandomString(8)}.xml",
            };
          
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(model.Filename);

            using (var outputStream = await cloudBlockBlob.OpenWriteAsync())
            {
                await file.CopyToAsync(outputStream);
            }

           // await _serviceBusQueueHelper.SendMessagesAsync(JsonConvert.SerializeObject(model), correlationId);
            return RedirectToAction("Confirmation", new { correlationId });
        }
    }
}