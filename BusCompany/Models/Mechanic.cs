using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Mechanic : Employees
    {
        private string qualification;
        public string Qualification { get => qualification; set => qualification = value; }
    }
}
