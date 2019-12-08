using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.DAO;
using BusCompany.Models;

namespace BusCompany.Controllers
{
    public class RouteController : Controller
    {
        RouteDAO routeDAO = new RouteDAO();

        // GET: Route
        public ActionResult Index()
        {
            return View(routeDAO.GetAllRoute());
        }

        // GET: Route/Details/5
        public ActionResult Details(int id)
        {
            List<Hult> hultList = routeDAO.GetHultById(id);
            int count = hultList.Count();
            if (count>0)
            {    
                Hult hult = hultList[hultList.Count - 1];
                hultList.RemoveAt(count-1);
                ViewBag.IDList = hultList;
                ViewBag.LustHult = hult.HultName;
            }            
            return View(routeDAO.GetById(id));
        }

        // GET: Route/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Route/Create
        [HttpPost]
        public ActionResult Create(Route route)
        {
            try
            {
                if (routeDAO.AddRout(route))
                    return RedirectToAction("Index");
                else return View("Create");
            }
            catch
            {
                return View("Create");
            }

        }

        // GET: Route/Edit/5
        public ActionResult Edit(int id)
        {
            return View(routeDAO.GetById(id));
        }

        // POST: Route/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Route route)
        {
            try
            {
                if (routeDAO.UpdateRoute(id, route.ApprovedStatus))
                    return RedirectToAction("Index");
                else return View("ErrorStatus");
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: Route/Delete/5
        public ActionResult Delete(int id)
        {
            return View(routeDAO.GetById(id));
        }

        // POST: Route/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (routeDAO.DeleteRoute(id))
                    return RedirectToAction("Index");
                else return View("Delete");
            }
            catch
            {
                return View();
            }
        }
    }
}
