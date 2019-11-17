using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusCompany.Models;

namespace BusCompany.DAO
{
    public class BusDAO : ClassDAO
    {
        public List<Bus> GetAll()
        {
            Connect();
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который возвращает список всех автобусов.");

            List<Bus> busList = new List<Bus>();
            SqlCommand commandRead = new SqlCommand("SELECT*FROM Bus;", Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Bus bus = new Bus();
                        bus.NumberPlate = Convert.ToString(reader["NumberPlate"]);
                        bus.Mark = Convert.ToString(reader["Mark"]);
                        bus.TechnicalStatus = Convert.ToBoolean(reader["TechnicalStatus"]);
                        bus.Speed = Convert.ToInt32(reader["Speed"]);
                        bus.FuelConsumption = Convert.ToInt32(reader["FuelConsumption"]);
                        bus.Mileage = Convert.ToInt32(reader["Mileage"]);
                        bus.Status = Convert.ToBoolean(reader["Status"]);
                        busList.Add(bus);
                    }
                }
            }
            catch (SqlException e)
            {
                log.Error("ERROR" + e.Message);
            }
            finally
            {
                reader.Close();
                Disconnect();
            }

            return busList;
        }

        public Bus GetById(string id)
        {
            Connect(); Bus bus = new Bus();
            string query = "SELECT*FROM Bus where numberPlate='" + id+"'";
            SqlCommand commandRead = new SqlCommand(query, Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    bus.NumberPlate = Convert.ToString(reader["NumberPlate"]);
                    bus.Mark = Convert.ToString(reader["Mark"]);
                    bus.TechnicalStatus = Convert.ToBoolean(reader["TechnicalStatus"]);
                    bus.Speed = Convert.ToInt32(reader["Speed"]);
                    bus.FuelConsumption = Convert.ToInt32(reader["FuelConsumption"]);
                    bus.Mileage = Convert.ToInt32(reader["Mileage"]);
                    bus.Status = Convert.ToBoolean(reader["Status"]);
                }
            }
            reader.Close();
            Disconnect();

            return bus;
        }

    }
}