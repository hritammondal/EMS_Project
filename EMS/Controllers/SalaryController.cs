using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    [Authorize]
    public class SalaryController : Controller
    {
        private EMSEntities1 db = new EMSEntities1();
        // GET: Salary
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployeeSalary()
        {
            return View();
        }

        public ActionResult EmployeeSalDet(int id)
        {
            var employee = db.Employees.ToList().Where(e => e.EmpID == id);
            return View(employee);
        }
    }
}