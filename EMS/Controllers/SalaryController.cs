using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    [Authorize]
    public class SalaryController : Controller
    {
        // GET: Salary
        public ActionResult Index()
        {
            return View();
        }
    }
}