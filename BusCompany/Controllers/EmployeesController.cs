using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.DAO;
using BusCompany.Models;

namespace BusCompany.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesDAO employeesDAO = new EmployeesDAO();
        DriverDAO driverDAO = new DriverDAO();
        MechanicDAO mechanicDAO = new MechanicDAO();
        ConductorDAO conductorDAO = new ConductorDAO();

        // GET: Employees
        public ActionResult Index()
        {
            return View(employeesDAO.GetAllEmployees());
        }

        // GET: Employees/Details/5
        public ActionResult DetailsEmployees(int id)
        {
            return View(employeesDAO.GetById(id));
        }

        // GET: Employees/Details/5
        public ActionResult DetailsDriver(int id)
        {
            return View(driverDAO.GetById(id));
        }

        // GET: Employees/Details/5
        public ActionResult DetailsMechanic(int id)
        {
            return View(mechanicDAO.GetById(id));
        }

        // GET: Employees/Details/5
        public ActionResult DetailsConductor(int id)
        {
            return View(conductorDAO.GetById(id));
        }



        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "d")] Employees empl)
        {
            try
            {
                if (employeesDAO.AddEmployees(empl))
                    return RedirectToAction("Index");
                else return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View(employeesDAO.GetById(id));
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employees empl)
        {
            try
            {
                if (employeesDAO.EditEmployees(id, empl))
                    return RedirectToAction("Index");
                else return View("Edit");
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View(employeesDAO.GetById(id));
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (employeesDAO.DeleteEmployees(id)) 
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
