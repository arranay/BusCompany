using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Employees
    {
        protected int personnelNumber;
        protected string lastName;
        protected string firstName;
        protected string middleName;
        protected DateTime dateOfBirth;
        protected int experience;
        protected decimal salary;
        protected string position;

        public int PersonnelNumber { get => personnelNumber; set => personnelNumber = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public int Experience { get => experience; set => experience = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public string Position { get => position; set => position = value; }
    }
}