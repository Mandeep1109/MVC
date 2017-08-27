using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcWithEntityF.Models
{
        [Table("Department")]
    public class Department
    {
            public int DepartmentId { get; set; }
        public string Name { get; set; }
    }
}