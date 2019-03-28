using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            Product[] array = {
                 new Product{ Name="Kayak", Price=273M },
                 new Product{ Name="Lifejacket", Price = 48.95M},
                 new Product{ Name="Soccerball", Price = 19.50M},
                 new Product{ Name="Corner flag", Price = 34.95M},
            };
            return View(array);
        }
            //Product myProduct = new Product
            //{
            //    ProductID = 1,
            //    Name = "Kayak",
            //    Description = "А boat for one person",
            //    Category = "Watersports",
            //    Price = 275M
            //};
            //ViewBag.StockLevel = 0;
            //return View(myProduct);
        
       
    }
}
