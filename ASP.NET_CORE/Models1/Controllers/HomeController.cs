using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models1.Models;

namespace Models1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            PlainModel model = new PlainModel()
            {
                Compane = "Microsoft",
               Salary = 10000,
               Emploees = 100000
            };
            int totalSalary = model.Salary * model.Emploees;
            string company = $"Company: {model.Compane}/n";
            string employees = $"Employees:{model.Emploees}/n";
            string salary = $"Salary:{model.Salary}/n";
            return company + salary + employees;

            //ThickModel model = new ThickModel("Microsoft", 1000000, 2000);
            //int totalSalary = model.TotalSalary();
            //string company = $"Company: {model.Compane}/n";
            //string employees = $"Employees:{model.Emploees}/n";
            //string salary = $"Salary:{model.Salary}/n";
            //return company + salary + employees;
        }
    }
}
