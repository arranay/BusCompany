using BusCompany.DAO;
using BusCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusCompany.Controllers
{
    public class WaybilController : Controller
    {
        WaybillDAO waybilDAO = new WaybillDAO();
        
        // GET: Waybil
        public ActionResult Index()
        {
            return View(waybilDAO.GetAllWaybil());
        }

        // GET: Waybil/Details/5
        public ActionResult Details(int id)
        {
            return View(waybilDAO.GetById(id));
        }

        // GET: Waybil/Create
        public ActionResult Create()
        {
            IEnumerable<string> bus = waybilDAO.GetAllBus();
            ViewBag.AllBus =new SelectList(bus);
            IEnumerable<Route> route = waybilDAO.GetAllRoute();
            ViewBag.AllRoute = new SelectList(route, "id", "routeName");
            IEnumerable<Driver> drivers = waybilDAO.GetAllDriver();
            ViewBag.AllDriver = new SelectList(drivers, "personnelNumber", "LastName");
            IEnumerable<Conductor> conductors = waybilDAO.GetAllConductor();
            ViewBag.AllConductor = new SelectList(conductors, "personnelNumber", "LastName");
            return View();
        }

        // POST: Waybil/Create
        [HttpPost]
        public ActionResult Create(Waybil waybil)
        {
            try
            {
                IEnumerable<Route> route = waybilDAO.GetAllRoute();
                ViewBag.AllRoute = new SelectList(route, "id", "routeName");
                IEnumerable<Driver> drivers = waybilDAO.GetAllDriver();
                ViewBag.AllDriver = new SelectList(drivers, "personnelNumber", "LastName");
                IEnumerable<Conductor> conductors = waybilDAO.GetAllConductor();
                ViewBag.AllConductor = new SelectList(conductors, "personnelNumber", "LastName");
                if (waybilDAO.AddWaybil(waybil))
                    return RedirectToAction("Index");
                else return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Waybil/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<string> bus = waybilDAO.GetAllBus();
            ViewBag.AllBus = new SelectList(bus);
            IEnumerable<Route> route = waybilDAO.GetAllRoute();
            ViewBag.AllRoute = new SelectList(route, "id", "routeName");
            IEnumerable<Driver> drivers = waybilDAO.GetAllDriver();
            ViewBag.AllDriver = new SelectList(drivers, "personnelNumber", "LastName");
            IEnumerable<Conductor> conductors = waybilDAO.GetAllConductor();
            ViewBag.AllConductor = new SelectList(conductors, "personnelNumber", "LastName");
            return View(waybilDAO.GetById(id));
        }

        // POST: Waybil/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Waybil waybil)
        {
            try
            {
                IEnumerable<string> bus = waybilDAO.GetAllBus();
                ViewBag.AllBus = new SelectList(bus);
                IEnumerable<Route> route = waybilDAO.GetAllRoute();
                ViewBag.AllRoute = new SelectList(route, "id", "routeName");
                IEnumerable<Driver> drivers = waybilDAO.GetAllDriver();
                ViewBag.AllDriver = new SelectList(drivers, "personnelNumber", "LastName");
                IEnumerable<Conductor> conductors = waybilDAO.GetAllConductor();
                ViewBag.AllConductor = new SelectList(conductors, "personnelNumber", "LastName");
                if (waybilDAO.UpdateWaybill(id, waybil))
                    return RedirectToAction("Index");
                else return View("Edit");
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: Waybil/Delete/5
        public ActionResult Delete(int id)
        {
            return View(waybilDAO.GetById(id));
        }

        // POST: Waybil/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (waybilDAO.DeleteWaybil(id))
                    return RedirectToAction("Index");
                else
                    return View("Delete");
            }catch
            {
                return View("Delete");
            }
        }
    }
}
