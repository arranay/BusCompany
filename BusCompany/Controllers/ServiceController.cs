using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusCompany.Models;
using BusCompany.DAO;

namespace BusCompany.Controllers
{
    public class ServiceController : Controller
    {
        ServiceDAO serviceDAO = new ServiceDAO();

        // GET: Service
        public ActionResult Index()
        {
            return View(serviceDAO.GetAllService());
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View(serviceDAO.GetById(id));
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            SelectList bus = new SelectList(serviceDAO.GetAllBus());
            ViewBag.AllBus = bus;
            IEnumerable<Mechanic> mechanics = serviceDAO.GetAllMechanic();
            ViewBag.AllMechanic = new SelectList(mechanics, "personnelNumber", "LastName");
            if (bus.Count() == 0)
            {
                return View("ErrorBus");
            }
            if (mechanics.Count() == 0)
            {
                return View("ErrorMechanic");
            }
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(Service service)
        {
            try
            {
                IEnumerable<Mechanic> mechanics = serviceDAO.GetAllMechanic();
                ViewBag.AllMechanic = new SelectList(mechanics, "personnelNumber", "LastName");
                if (serviceDAO.AddService(service))
                    return RedirectToAction("Index");
                else return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            return View(serviceDAO.GetById(id));
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Service service
            )
        {
            try
            {
                if (serviceDAO.SetTypeOfWork(id, service))
                    return RedirectToAction("Index");
                else return View("Edit");

            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            return View(serviceDAO.GetById(id));
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (serviceDAO.DeleteService(id))
                    return RedirectToAction("Index");
                else return View("Delete");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
