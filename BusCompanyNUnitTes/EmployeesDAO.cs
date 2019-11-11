using NUnit.Framework;
using BusCompany.Models;
using BusCompany.DAO;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*[Test]
        public void GetByidTest()
        {
            string expected = "Мишин               ";
            EmployeesDAO employeesDAO = new EmployeesDAO();
            Employees employees = employeesDAO.GetById(4);
            string actual = employees.LastName;
            Assert.AreEqual(expected, actual);
        }*/

        [Test]
        public void SumTest()
        {
            int expected = 30;
            EmployeesDAO employeesDAO = new EmployeesDAO();
            int actual = employeesDAO.Sum(15, 15);
            Assert.AreEqual(expected, actual);
        }


    }
}