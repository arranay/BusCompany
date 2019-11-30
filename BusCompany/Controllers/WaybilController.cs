using BusCompany.DAO;
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
            return View();
        }

        // POST: Waybil/Create
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

        // GET: Waybil/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Waybil/Edit/5
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
