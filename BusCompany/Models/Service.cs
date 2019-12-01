﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusCompany.Models
{
    public class Service
    {
        private int id;
        private string idBus;
        private int idEmployees;
        private DateTime serviceDate;
        private string typeOfWork;

        public int Id { get => id; set => id = value; }
        public string IdBus { get => idBus; set => idBus = value; }
        public int IdEmployees { get => idEmployees; set => idEmployees = value; }
        [DataType(DataType.Date)]
        public DateTime ServiceDate { get => serviceDate; set => serviceDate = value; }
        public string TypeOfWork { get => typeOfWork; set => typeOfWork = value; }
        public Bus Bus { get => bus; set => bus = value; }
        public Employees Employees { get => employees; set => employees = value; }

        private Bus bus;
        private Employees employees;
    }
}