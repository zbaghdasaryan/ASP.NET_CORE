using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            List<string> result = new List<string>();
            foreach (var p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<No Name>";
                result.Add(string.Format("Name: {0},  Price: {1},  Related: {2}", name, price, relatedName));
            }
            // return View(new string[] { "C#", "Language", "Features" });
            //return View(result);
            return View("Index", new string[] { "ВоЬ", "Joe", "Alice" });
        }
    }
}
