using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Waybill
    {
        private int id;
        private int routId;
        private int driverId;
        private int conductorId;
        private string busId;
        private DateTime date;

        private Route route;
        private Driver driver;
        private Conductor conductor;
        private Bus bus;

        public int Id { get => id; set => id = value; }
        public int RoutId { get => routId; set => routId = value; }
        public int DriverId { get => driverId; set => driverId = value; }
        public int ConductorId { get => conductorId; set => conductorId = value; }
        public string BusId { get => busId; set => busId = value; }
        [DataType(DataType.Date)]
        public DateTime Date { get => date; set => date = value; }
        public Route Route { get => route; set => route = value; }
        public Driver Driver { get => driver; set => driver = value; }
        public Conductor Conductor { get => conductor; set => conductor = value; }
        public Bus Bus { get => bus; set => bus = value; }
    }
}