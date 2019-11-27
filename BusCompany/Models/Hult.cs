using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Hult
    {
        private int id;
        private string hultName;
        private int routNumber;

        public int Id { get { return id; } set { id = value; } }
        public string HultName { get { return hultName; } set { hultName = value; } }
        public int RoutNumber { get => routNumber; set => routNumber = value; }
    }
}