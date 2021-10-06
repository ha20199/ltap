using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ltap.Areas.Employees.Controllers
{
    [Authorize (Roles = "NV")]
    public class HomeEmployeesController : Controller
    {
        // GET: Employees/HomeEmployees
        public ActionResult Index()
        {
            return View();
        }
    }
}