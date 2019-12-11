using System;
using System.ComponentModel.DataAnnotations;

namespace BusCompany.Models
{
    public class Employees
    {
        private int personnelNumber;
        private string lastName;
        private string firstName;
        private string middleName;
        private DateTime dateOfBirth;
        private int experience;
        private decimal salary;
        private string position;
        private decimal prize;

        public int PersonnelNumber { get => personnelNumber; set => personnelNumber = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [RegularExpression(@"^[A-ЯЁ][а-яё]+\s*",
            ErrorMessage = "Фамилия должна начинатся с заглавной буквы, включать в стебя только русские символы, " +
            "без цифр и посторонних знаков.")]
        public string LastName { get => lastName; set => lastName = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [RegularExpression(@"^[A-ЯЁ][а-яё]+\s*",
           ErrorMessage = "Имя должно начинатся с заглавной буквы, включать в стебя только русские символы, " +
           "без цифр и посторонних знаков.")]
        public string FirstName { get => firstName; set => firstName = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [RegularExpression(@"^[A-ЯЁ][а-яё]+\s*",
           ErrorMessage = "Отчество должно начинатся с заглавной буквы, включать в стебя только русские символы, " +
           "без цифр и посторонних знаков.")]
        public string MiddleName { get => middleName; set => middleName = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        public int Experience { get => experience; set => experience = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        public decimal Salary { get => salary; set => salary = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        public string Position { get => position; set => position = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        public decimal Prize { get => prize; set => prize = value; }

        public Employees(string lName, string fName, string mName, int exp, decimal sal)
        {
            LastName = lName;
            FirstName = fName;
            MiddleName = mName;
            Experience = exp;
            Salary = sal;
        }

        public Employees()
        {

        }

        public Employees(string lastName, string firstName, string middleName, DateTime dateOfBirth, int experience, decimal salary, string position)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.DateOfBirth = dateOfBirth;
            this.Experience = experience;
            this.Salary = salary;
            this.Position = position;
        }

       
    }
}