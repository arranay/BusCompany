using NUnit.Framework;
using BusCompany.Models;
using BusCompany.DAO;
using System;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void TestAddBus()
        {
            string expectation = "фф123ф";

            BusDAO busDAO = new BusDAO();
            Bus bus = new Bus();
            bus.NumberPlate = "фф123ф"; bus.Mark = "ВАЗ";
            bus.Speed = 123; bus.FuelConsumption = 123; bus.Mileage = 123;
            busDAO.AddBus(bus);

            string reality = busDAO.GetById("фф123ф").NumberPlate;
            Assert.Equals(expectation, reality);
        }

        [Test]
        public void TestUpdatestatus()
        {
            //в предыдущем тесте мы добавили новый автобус. У всех новых автобусов статус true
            //теперь попробуем сменить статус на false
            Bus bus = new Bus(); bus.TechnicalStatus = false; bus.Mileage = 123;
            new BusDAO().UpdateBus("фф123ф", bus);
            //проверяем
            Assert.Equals(false, new BusDAO().GetById("фф123ф").TechnicalStatus);
        }

        [Test]
        public void TestDeleteBus()
        {
            //удаляем автобус, который был создан для тестов и проверяем удаление
            Assert.Equals(true, new BusDAO().DeletBus("фф123ф"));
        }

        [Test]
        public void TestDeleteEmployees()
        {
            Employees employees = new Employees("Иванов","Иван","Иванович",new DateTime(129078),12,12, "кондуктор           ");
            int id = new EmployeesDAO().AddEmployees(employees);
            bool reality = new EmployeesDAO().DeleteEmployees(id);
            Assert.Equals(true, reality);
        }
    }
}