using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcWithEntityF.Models
{
    public class EmployeeContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        //public System.Data.Entity.DbSet<mvcWithEntityF.Models.Department> Departments { get; set; }
    }
}