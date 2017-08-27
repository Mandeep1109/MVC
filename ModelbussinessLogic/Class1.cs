using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ModelbussinessLogic
{
    public class EmployeeBussiness
    {
        public IEnumerable<Employee> Employees
        {
            
            get
            {
                List<Employee> emp =new List<Employee>();
                string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
                string query = "Select * from Employee";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee empObject = new Employee();
                    empObject.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                    empObject.Name = dr["Name"].ToString();
                    empObject.Gender = dr["Gender"].ToString();
                    empObject.City = dr["City"].ToString();
                    empObject.DepartmentId =Convert.ToInt32(dr["DepartmentId"]);
                    emp.Add(empObject);
                }
                con.Close();
                return emp;
            }
           
        }
        public void AddEmployee(Employee emp)
        {
            //Add Database Insert code here
        }
        public void EditEmployee(Employee emp)
        {
            //Add Database Edit code here
        }
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int DepartmentId { get; set; }
    }
}
