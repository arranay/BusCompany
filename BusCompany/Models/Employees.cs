using System;
using System.ComponentModel.DataAnnotations;

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

        [Range(1, 100, ErrorMessage = "Опыт работы не может быть отрицательным и превышать отметку 100")]
        [Required(ErrorMessage = "Данное поле является обязательным")]
        public int Experience { get => experience; set => experience = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [Range(10000, 70000, ErrorMessage = "Проверьте введённую сумму")]
        public decimal Salary { get => salary; set => salary = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        public string Position { get => position; set => position = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [Range(1000, 30000, ErrorMessage = "Проверьте введённую сумму")]
        public decimal Prize { get => prize; set => prize = value; }

        public Employees(string lName, string fName, string mName, int exp, decimal sal)
        {
            lastName = lName;
            firstName = fName;
            middleName = mName;
            experience = exp;
            salary = sal;
        }

        public Employees()
        {

        }

        public Employees(string lastName, string firstName, string middleName, DateTime dateOfBirth, int experience, decimal salary, string position)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleName = middleName;
            this.dateOfBirth = dateOfBirth;
            this.experience = experience;
            this.salary = salary;
            this.position = position;
        }

       
    }
}