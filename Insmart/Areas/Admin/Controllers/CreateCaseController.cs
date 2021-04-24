using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insmart.Areas.Admin.Controllers
{
    public class CreateCaseController : Controller
    {
        // GET: Admin/CreateCase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PatientDetails()
        {
            return View();
        }
    }
}