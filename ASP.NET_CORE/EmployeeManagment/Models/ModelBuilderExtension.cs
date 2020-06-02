using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Name = "Zoro",
                Department = Dept.C_Sharp,
                Email = "zoro@utaxi.com"
            },
                new Employee
                {
                    Id = 2,
                    Name = "Avo",
                    Department = Dept.PM,
                    Email = "Avo@utaxi.com"
                }
            );
        }
    }
}
