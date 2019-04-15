using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM_Project.Models;

namespace CRM_Project.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public ViewResult Continue()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Save(Users guestResponse)
        {

            if (ModelState.IsValid)
            {
                UsersList.AddUser(guestResponse);
                return View("AddMember", guestResponse);
            }
            else

                return View();
        }
    }
}
