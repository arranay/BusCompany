using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View();
        }

        // POST: Service/Create
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

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Service/Edit/5
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
