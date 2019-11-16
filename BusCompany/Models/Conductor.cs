using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Conductor : Employees
    {
        private bool onRoute;
        public bool OnRoute { get => onRoute; set => onRoute = value; }
    }
}