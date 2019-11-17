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


        public ActionResult DetailsDriver(int id)
        {
            return View(driverDAO.GetById(id));
        }


        public ActionResult DetailsMechanic(int id)
        {
            return View(mechanicDAO.GetById(id));
        }


        public ActionResult DetailsConductor(int id)
        {
            return View(conductorDAO.GetById(id));
        }

        //*************************Create***************************************

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "d")] Employees empl)
        {
            int id = employeesDAO.AddEmployees(empl);

            switch (empl.Position)
            {
                case "водитель":
                    try
                    {
                        if (id > 0)
                        {
                            return RedirectToAction("CreateDriver/" + id);
                        }
                        else return View("Create");
                    }
                    catch
                    {
                        return View("Create");
                    }
                    

                case "механик":
                    try
                    {
                        if (id > 0)
                        {
                            return RedirectToAction("CreateMechanic/" + id);
                        }
                        else return View("Create");
                    }
                    catch
                    {
                        return View("Create");
                    }

                case "кондуктор":
                    try
                    {
                        if ((id > 0)&&(conductorDAO.AddConductor(id)))
                        {
                            return RedirectToAction("Index");
                        }
                        else return View("Create");
                    }
                    catch
                    {
                        return View("Create");
                    }

                default:
                    try
                    {
                        if (id > 0)
                            return RedirectToAction("Index");
                        else return View("Create");
                    }
                    catch
                    {
                        return View("Create");
                    }

            }
        }

        public ActionResult CreateDriver(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDriver([Bind(Exclude = "d")] Driver driver, int id)
        {
            try
            {
                if (driverDAO.AddDriver(driver, id))
                    return RedirectToAction("Index");
                else return View("CreateDriver");
            }
            catch
            {
                return View("CreateDriver");
            }
        }

        public ActionResult CreateMechanic(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMechanic([Bind(Exclude = "d")] Mechanic mechanic, int id)
        {
            try
            {
                if (mechanicDAO.AddMechanic(mechanic, id))
                    return RedirectToAction("Index");
                else return View("CreateMechanic");
            }
            catch
            {
                return View("CreateMechanic");
            }
        }



        //*************************Edit***************************************
        
        public ActionResult EditEmployees(int id)
        {
            return View(employeesDAO.GetById(id));
        }

      
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

        
        public ActionResult EditDriver(int id)
        {
            return View(driverDAO.GetById(id));
        }

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

        public ActionResult EditMechanic(int id)
        {
            return View(mechanicDAO.GetById(id));
        }

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

        public ActionResult DeleteEmployees(int id)
        {
            return View(employeesDAO.GetById(id));
        }

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


        public ActionResult DeleteMechanic(int id)
        {
            return View(mechanicDAO.GetById(id));
        }

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

        public ActionResult DeleteConductor(int id)
        {
            return View(conductorDAO.GetById(id));
        }

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

        public ActionResult DeleteDriver(int id)
        {
            return View(driverDAO.GetById(id));
        }

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
