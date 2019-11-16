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

        //*************************Details***************************************

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

        //*************************Create***************************************

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

        //*************************Edit***************************************

        // GET: Employees/Edit/5
        public ActionResult EditEmployees(int id)
        {
            return View(employeesDAO.GetById(id));
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult EditEmployees(int id,Employees empl)
        {
            try
            {
                if (employeesDAO.EditEmployees(id, empl))
                    return RedirectToAction("Index");
                else return View("EditEmployees");
            }
            catch
            {
                return View("EditEmployees");
            }
        }

        
        // GET: Employees/Edit/5
        public ActionResult EditDriver(int id)
        {
            return View(driverDAO.GetById(id));
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult EditDriver(int id, Driver driver)
        {
            try
            {
                if (driverDAO.EditDriver(id, driver))
                    return RedirectToAction("Index");
                else return View("EditDriver");
            }
            catch
            {
                return View("EditDriver");
            }
        }

        // GET: Employees/Edit/5
        public ActionResult EditMechanic(int id)
        {
            return View(mechanicDAO.GetById(id));
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult EditMechanic(int id, Mechanic mechanic)
        {
            try
            {
                if (mechanicDAO.EditMechanic(id, mechanic))
                    return RedirectToAction("Index");
                else return View("EditMechanic");
            }
            catch
            {
                return View("EditMechanic");
            }
        }

        //*************************Delete***************************************

        // GET: Employees/Delete/5
        public ActionResult DeleteEmployees(int id)
        {
            return View(employeesDAO.GetById(id));
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult DeleteEmployees(int id, FormCollection collection)
        {
            try
            {
                if (employeesDAO.DeleteEmployees(id)) 
                    return RedirectToAction("Index");
                else return View("DeleteEmployees");
            }
            catch
            {
                return View("DeleteEmployeese");
            }
        }


        // GET: Employees/Delete/5
        public ActionResult DeleteMechanic(int id)
        {
            return View(mechanicDAO.GetById(id));
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult DeleteMechanic(int id, FormCollection collection)
        {
            try
            {
                if (mechanicDAO.DeleteMechanic(id))
                    return RedirectToAction("Index");
                else return View("DeleteMechanic");
            }
            catch
            {
                return View("DeleteMechanic");
            }
        }

        // GET: Employees/Delete/5
        public ActionResult DeleteConductor(int id)
        {
            return View(conductorDAO.GetById(id));
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult DeleteConductor(int id, FormCollection collection)
        {
            try
            {
                if (conductorDAO.DeleteConductor(id))
                    return RedirectToAction("Index");
                else return View("DeleteConductor");
            }
            catch
            {
                return View("DeleteConductor");
            }
        }

        // GET: Employees/Delete/5
        public ActionResult DeleteDriver(int id)
        {
            return View(driverDAO.GetById(id));
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult DeleteDriver(int id, FormCollection collection)
        {
            try
            {
                if (driverDAO.DeleteDriver(id))
                    return RedirectToAction("Index");
                else return View(" DeleteDriver");
            }
            catch
            {
                return View(" DeleteDriver");
            }
        }
    }
}
