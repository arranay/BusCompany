using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Service
    {
        private int id;
        private string idBus;
        private int idEmployees;
        private DateTime date;
        private string typeOfWork;

        public int Id { get => id; set => id = value; }
        public string IdBus { get => idBus; set => idBus = value; }
        public int IdEmployees { get => idEmployees; set => idEmployees = value; }
        [DataType(DataType.Date)]
        public DateTime Date { get => date; set => date = value; }
        public string TypeOfWork { get => typeOfWork; set => typeOfWork = value; }
    }
}