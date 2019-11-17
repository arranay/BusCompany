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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bus/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bus/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bus/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
