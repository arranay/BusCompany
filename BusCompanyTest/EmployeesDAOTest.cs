using NUnit.Framework;
using BusCompany.DAO;
using BusCompany.Models;

namespace Tests
{
    [TestFixture]
    public class EmployeesDAOTest
    {
        [Test]
        public void TestGetById()
        {
            Employees em = new Employees();
            EmployeesDAO employeesDAO = new EmployeesDAO();
            em = employeesDAO.GetById(4);

            string expectedName = "Михаил";
            string actualName = em.FirstName;

            Assert.Equals(expectedName, actualName);
        }
    }
}