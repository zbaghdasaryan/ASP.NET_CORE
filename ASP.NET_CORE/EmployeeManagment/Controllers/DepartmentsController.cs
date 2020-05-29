using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controllers
{
    public class DepartmentsController : Controller
    {
        public string List()
        {
            return "List() of DepartmentsController";
        }
        public string Details()
        {
            return "Detalis() of DepartmentsController";
        }
    }
}
