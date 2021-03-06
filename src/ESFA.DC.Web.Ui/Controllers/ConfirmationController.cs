﻿using DC.Web.Ui.ViewModels;
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
            IlrFileViewModel ilrSubmission = null;
            var tempData = TempData["ilrSubmission"];
            if (tempData  != null)
            {
                ilrSubmission = JsonConvert.DeserializeObject<IlrFileViewModel>(tempData.ToString());
            }

            return View(ilrSubmission);
        }
    }
}