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
            string expectation = "��123�";

            BusDAO busDAO = new BusDAO();
            Bus bus = new Bus();
            bus.NumberPlate = "��123�"; bus.Mark = "���";
            bus.Speed = 123; bus.FuelConsumption = 123; bus.Mileage = 123;
            busDAO.AddBus(bus);

            string reality = busDAO.GetById("��123�").NumberPlate;
            Assert.Equals(expectation, reality);
        }

        [Test]
        public void TestUpdatestatus()
        {
            //� ���������� ����� �� �������� ����� �������. � ���� ����� ��������� ������ true
            //������ ��������� ������� ������ �� false
            Bus bus = new Bus(); bus.TechnicalStatus = false; bus.Mileage = 123;
            new BusDAO().UpdateBus("��123�", bus);
            //���������
            Assert.Equals(false, new BusDAO().GetById("��123�").TechnicalStatus);
        }

        [Test]
        public void TestDeleteBus()
        {
            //������� �������, ������� ��� ������ ��� ������ � ��������� ��������
            Assert.Equals(true, new BusDAO().DeletBus("��123�"));
        }

        [Test]
        public void TestDeleteEmployees()
        {
            Employees employees = new Employees("������","����","��������",new DateTime(129078),12,12, "���������           ");
            int id = new EmployeesDAO().AddEmployees(employees);
            bool reality = new EmployeesDAO().DeleteEmployees(id);
            Assert.Equals(true, reality);
        }
    }
}