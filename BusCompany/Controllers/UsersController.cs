using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.DAO;
using BusCompany.Models;

namespace BusCompany.Controllers
{
    public class UsersController : Controller
    {
        UsersDAO usersDAO = new UsersDAO();
        // GET: Users
        public ActionResult Index()
        {
            return View(usersDAO.GetAllUser());
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            IEnumerable<Role> role = usersDAO.GetAllRole();
            ViewBag.AllRole = new SelectList(role, "id", "Name");
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Users user)
        {
            try
            {
                IEnumerable<Role> role = usersDAO.GetAllRole();
                ViewBag.AllRole = new SelectList(role, "id", "Name");
                if (usersDAO.AddRole(user)) return RedirectToAction("Index");
                else return View("Edit");
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
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
