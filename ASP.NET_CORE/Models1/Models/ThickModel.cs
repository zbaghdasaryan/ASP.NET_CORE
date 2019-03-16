using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models1.Models
{
    public class ThickModel
    {
        public string Compane { get; set; }
        public int Emploees { get; set; }
        public int Salary { get; set; }

        public ThickModel(string company, int employees, int salary)
        {
            Compane = company;
            Emploees = employees;
            Salary = salary;
        }

        public int TotalSalary()
        {
            return Emploees * Salary;
        }
    }
}
