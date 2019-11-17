using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.DAO;
using BusCompany.Models;

namespace BusCompany.Controllers
{
    public class BusController : Controller
    {
        BusDAO busDAO = new BusDAO();

        // GET: Bus
        public ActionResult Index()
        {
            return View(busDAO.GetAll());
        }

        // GET: Bus/Details/5
        public ActionResult Details(string id)
        {
            return View(busDAO.GetById(id));
        }

        // GET: Bus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bus/Create
        [HttpPost]
        public ActionResult Create(Bus bus)
        {
            try
            {
                if (busDAO.AddBus(bus))
                    return RedirectToAction("Index");
                else return View("Create");
            }
            catch
            {
                return View("Create");
            }

        }

        // GET: Bus/Edit/5
        public ActionResult Edit(string id)
        {
            return View(busDAO.GetById(id));
        }

        // POST: Bus/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Bus bus)
        {

            try
            {
                if (busDAO.UpdateBus(id, bus))
                    return RedirectToAction("Index");
                else return View("Edit");

            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: Bus/Delete/5
        public ActionResult Delete(string id)
        {
            return View(busDAO.GetById(id));
        }

        // POST: Bus/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                if (busDAO.DeletBus(id))
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
