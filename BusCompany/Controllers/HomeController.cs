using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusCompany.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View("IndexAdmin");
            }
            if (User.IsInRole("Dispetcher"))
            {
                return View("IndexDispetcher");
            }
            if (User.IsInRole("HumanResources"))
            {
                return View("IndexHumanResources");
            }
            if (User.IsInRole("Master"))
            {
                return View("IndexMaster");
            }
            if (User.IsInRole("Accountant"))
            {
                return View("IndexAccountant");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}