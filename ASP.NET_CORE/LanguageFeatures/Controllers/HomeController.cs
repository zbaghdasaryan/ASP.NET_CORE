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

            //Dictionary<string, Product> product = new Dictionary<string, Product> {
            //    { "Kayak",new Product{Name="Kayak",Price=275M } },
            //    { "Lifejacket", new Product{ Name = "Lifejacket", Price = 48.95M }
            //    }
            //};
            //return View("Index", product.Keys);

            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            decimal cartTotal = cart.TotalPrices();
            return View(" Index", new string[] { $" Total: { cartTotal: С2}" });

            //List<string> result = new List<string>();
            //foreach (var p in Product.GetProducts())
            //{
            //    string name = p?.Name ?? "<No Name>";
            //    decimal? price = p?.Price ?? 0;
            //    string relatedName = p?.Related?.Name ?? "<No Name>";
            //    result.Add(string.Format("Name: {0},  Price: {1},  Related: {2}", name, price, relatedName));
        }
        // return View(new string[] { "C#", "Language", "Features" });
        //return View(result);
        //return View("Index", new string[] { "ВоЬ", "Joe", "Alice" });
    }
}

