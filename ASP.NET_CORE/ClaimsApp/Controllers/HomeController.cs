using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClaimsApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClaimsApp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Policy = "OnlyForLondon")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "OnlyForMicrosoft")]
        public IActionResult About()
        {
            return Content("Only for Microsoft employees");
        }
    }
}
