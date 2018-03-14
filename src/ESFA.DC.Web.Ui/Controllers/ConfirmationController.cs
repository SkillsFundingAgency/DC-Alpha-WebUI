using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DC.Web.Ui.Controllers
{
    public class ConfirmationController : Controller
    {
        public IActionResult Index(string correlationId)
        {
            ViewData["CorrelationId"] = correlationId;

            return View();
        }
    }
}