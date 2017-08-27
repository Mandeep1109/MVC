using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcWithEntityF.Models;
using System.Data;
using ModelbussinessLogic;

namespace mvcWithEntityF.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(int id)
        {
            EmployeeContext emp1 = new EmployeeContext();
            mvcWithEntityF.Models.Employee empl=emp1.Employees.Single(emp => emp.EmployeeId == id);
            return View(empl);
        }
        public ActionResult EmployeeList()
        {
            EmployeeContext emp1 = new EmployeeContext();
            List<mvcWithEntityF.Models.Employee> employee = emp1.Employees.ToList();
            return View(employee);
        }

        public ActionResult DepartmentList()
        {
            DepartmentContext departmentContext = new DepartmentContext();
            List<Department> department = departmentContext.Departments.ToList();
            return View(department);
        }
        public ActionResult EmployeeListFromBLogic()
        {
            EmployeeBussiness eb = new EmployeeBussiness();
            List<ModelbussinessLogic.Employee> emp = eb.Employees.ToList();
            return View(emp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //RECIEVE FORM DATA USING 4 WAYS
        // 1.
        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    ModelbussinessLogic.Employee emp = new ModelbussinessLogic.Employee();
        //    emp.DepartmentId = Convert.ToInt32(formCollection["DepartmentId"]);
        //    emp.Name = Convert.ToString(formCollection["Name"]);
        //    emp.Gender = Convert.ToString(formCollection["Gender"]);
        //    emp.City = Convert.ToString(formCollection["City"]);
        //    ModelbussinessLogic.EmployeeBussiness empB = new ModelbussinessLogic.EmployeeBussiness();
        //    empB.AddEmployee((ModelbussinessLogic.Employee)emp);
        //    return View();
        //}

        // 2.
        //[HttpPost]
        //public ActionResult Create(int DepartmentId,string Name,string Gender,string City)
        //{
        //    ModelbussinessLogic.Employee emp = new ModelbussinessLogic.Employee();
        //    emp.DepartmentId = DepartmentId;
        //    emp.Name = Name;
        //    emp.Gender = Gender;
        //    emp.City = City;
        //    ModelbussinessLogic.EmployeeBussiness empB = new ModelbussinessLogic.EmployeeBussiness();
        //    empB.AddEmployee((ModelbussinessLogic.Employee)emp);
        //    return View();
        //}
        // 3.
        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_1()
        //{
        //    ModelbussinessLogic.Employee emp = new ModelbussinessLogic.Employee();
        //    UpdateModel(emp);
        //    ModelbussinessLogic.EmployeeBussiness empB = new ModelbussinessLogic.EmployeeBussiness();
        //    empB.AddEmployee((ModelbussinessLogic.Employee)emp);
        //    return View();
        //}
        // 4.
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(ModelbussinessLogic.Employee emp)
        {
            ModelbussinessLogic.EmployeeBussiness empB = new ModelbussinessLogic.EmployeeBussiness();
            empB.AddEmployee((ModelbussinessLogic.Employee)emp);
            return View();
        }
        public ActionResult Edit(int id)
        {
            EmployeeContext emp1 = new EmployeeContext();
            mvcWithEntityF.Models.Employee empl = emp1.Employees.Single(emp => emp.EmployeeId == id);
            return View(empl);
        }
        [HttpPost] //
        public ActionResult Edit()
        {
            ModelbussinessLogic.Employee emp = new ModelbussinessLogic.Employee();
            UpdateModel(emp);
            ModelbussinessLogic.EmployeeBussiness empB = new ModelbussinessLogic.EmployeeBussiness();
            empB.EditEmployee((ModelbussinessLogic.Employee)emp);
            return View();
        }
    }
}