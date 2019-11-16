using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Driver : Employees
    {
        private string categories;
        private DateTime rightsDate;
        private bool onRoute;

        public string Categories { get => categories; set => categories = value; }
        [DataType(DataType.Date)]
        public DateTime RightsDate { get => rightsDate; set => rightsDate = value; }
        public bool OnRoute { get => onRoute; set => onRoute = value; }
    }
}