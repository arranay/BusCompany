using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Driver : Employees
    {
        private string categories;
        private string rightsDate;
        private bool onRoute;

        public string Categories { get => categories; set => categories = value; }
        public string RightsDate { get => rightsDate; set => rightsDate = value; }
        public bool OnRoute { get => onRoute; set => onRoute = value; }
    }
}