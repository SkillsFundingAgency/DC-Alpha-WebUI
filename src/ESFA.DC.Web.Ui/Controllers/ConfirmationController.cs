using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DC.Web.Ui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DC.Web.Ui.Controllers
{
    [Authorize]
    public class ConfirmationController : Controller
    {
        public IActionResult Index()
        {
            IlrSubmission ilrSubmission = null;
            var tempData = TempData["ilrSubmission"];
            if (tempData  != null)
            {
                ilrSubmission = JsonConvert.DeserializeObject<IlrSubmission>(tempData.ToString());
            }

            return View(ilrSubmission);
        }
    }
}