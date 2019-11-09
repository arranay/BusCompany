﻿using System.Collections.Generic;
using System.Web.Mvc;
using BusCompany.Models;
using BusCompany.DAO;

namespace BusCompany.Controllers
{
    public class HultController : Controller
    {
        HultDAO hultDAO = new HultDAO();

        // GET: Hult
        public ActionResult Index()
        {
            return View(hultDAO.GetAllHult());
        }

        // GET: Hult/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hult/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "d")] Hult hult)
        {
            try
            {
                if (hultDAO.AddHult(hult))
                    return RedirectToAction("Index");
                else return View("Create");
            }
            catch
            {
                return View("Create");
            }

        }

        // GET: Hult/Delete/5
        public ActionResult Delete(int id)
        {
            return View(hultDAO.GetById(id));

        }

        // POST: Hult/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (hultDAO.DeleteHult(id))
                    return RedirectToAction("Index");
                else return View("Delete");
            }
            catch
            {
                return View("Delete");
            }

        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View(hultDAO.GetById(id));
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Hult hult)
        {
            try
            {
                if (hultDAO.UpdateHult(id, hult))
                    return RedirectToAction("Index");
                else return View("Edit");

            }
            catch
            {
                return View("Edit");
            }
        }

    }
}
