using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Bus
    {
        private string numberPlate;
        private string mark;
        private bool technicalStatus;
        private int speed;
        private int fuelConsumption;
        private int mileage;
        private bool status;

        public string NumberPlate { get => numberPlate; set => numberPlate = value; }
        public string Mark { get => mark; set => mark = value; }
        public bool TechnicalStatus { get => technicalStatus; set => technicalStatus = value; }
        public int Speed { get => speed; set => speed = value; }
        public int FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }
        public int Mileage { get => mileage; set => mileage = value; }
        public bool Status { get => status; set => status = value; }
    }
}