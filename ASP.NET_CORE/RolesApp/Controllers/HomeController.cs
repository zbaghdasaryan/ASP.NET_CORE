using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RolesApp.Models;

namespace RolesApp.Controllers
{
    public class HomeController : Controller
    {

        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            return Content($"ваша роль: {role}");
        }
        
        [Authorize(Roles = "admin")]
        public IActionResult About()
        {
            return Content("Вход только для администратора");
        }
    }
}
