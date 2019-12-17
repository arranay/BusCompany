using System;
using System.ComponentModel.DataAnnotations;


namespace BusCompany.Models
{
    public class Driver : Employees
    {
        private string categories;
        private DateTime rightsDate;
        private bool onRoute;

        public string Categories { get => categories; set => categories = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [DataType(DataType.Date)]
        public DateTime RightsDate { get => rightsDate; set => rightsDate = value; }

        public bool OnRoute { get => onRoute; set => onRoute = value; }
    }
}