using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Employees
    {
        private int personnelNumber;
        private string lastName;
        private string firstName;
        private string middleName;
        private String dateOfBirth;
        private int experience;
        private decimal salary;
        private string position;

        public int PersonnelNumber { get => personnelNumber; set => personnelNumber = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public String DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public int Experience { get => experience; set => experience = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public string Position { get => position; set => position = value; }
    }
}