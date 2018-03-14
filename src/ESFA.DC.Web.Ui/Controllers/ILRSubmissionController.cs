using DC.Web.Ui.ClaimTypes;
using DC.Web.Ui.Extensions;
using DC.Web.Ui.Models;
using DC.Web.Ui.Services.Models;
using DC.Web.Ui.Services.ServiceBus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using DC.Web.Ui.Settings.Models;

namespace DC.Web.Ui.Controllers
{
    [Authorize(Policy = PolicyTypes.FileSubmission)]
    public class ILRSubmissionController : Controller
    {
        private readonly IServiceBusQueue _serviceBusQueue;
        private readonly CloudStorageSettings _cloudStorageSettings;
        public ILRSubmissionController(IServiceBusQueue serviceBusQueue, CloudStorageSettings cloudStorageSettings)
        {
            _serviceBusQueue = serviceBusQueue;
            _cloudStorageSettings = cloudStorageSettings;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(500_000_000)]
        public async Task<IActionResult> Submit(IFormFile file)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_cloudStorageSettings.ConnectionString);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(_cloudStorageSettings.ContainerName);

            var ilrFile = new IlrSubmission()
            {
                CorrelationId = Guid.NewGuid(),
                ContainerReference = _cloudStorageSettings.ContainerName,
                Filename = $" {Path.GetFileNameWithoutExtension(file.FileName).AppendRandomString(5)}.xml",
            };

            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(ilrFile.Filename);

            using (var outputStream = await cloudBlockBlob.OpenWriteAsync())
            {
                await file.CopyToAsync(outputStream);
            }

            await _serviceBusQueue.SendMessagesAsync(JsonConvert.SerializeObject(ilrFile), ilrFile.CorrelationId.ToString());
            return RedirectToAction("Index","Confirmation", new { ilrFile.CorrelationId });
        }
    }
}