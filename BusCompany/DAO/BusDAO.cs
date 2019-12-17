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
            string query = "SELECT*FROM Bus where numberPlate='@id'";
            SqlCommand commandRead = new SqlCommand(query, Connection);
            commandRead.Parameters.AddWithValue("@id", id);
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

        public bool AddBus(Bus bus)
        {

            Connect();
            try
            {
                string sql = "INSERT INTO Bus" +
                    "(NumberPlate, Mark, TechnicalStatus, Speed, FuelConsumption, Mileage, Status)" +
                    " VALUES (@NumberPlate, @Mark, @TechnicalStatus, @Speed, @FuelConsumption, @Mileage, @Status)";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@NumberPlate", bus.NumberPlate);
                cmd_SQL.Parameters.AddWithValue("@Mark", bus.Mark);
                cmd_SQL.Parameters.AddWithValue("@TechnicalStatus", true);
                cmd_SQL.Parameters.AddWithValue("@Speed", bus.Speed);
                cmd_SQL.Parameters.AddWithValue("@FuelConsumption", bus.FuelConsumption);
                cmd_SQL.Parameters.AddWithValue("@Mileage", bus.Mileage);
                cmd_SQL.Parameters.AddWithValue("@Status", false);
                cmd_SQL.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error("ERROR: " + e.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }

            return true;

        }

        public bool DeletBus(string id)
        {

            bool result = true;
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который удаляет автобус");
            Connect();
            try
            {
                string sql = "DELETE FROM Service WHERE idBus='@id';";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@id", id);
                cmd_SQL.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                log.Error("ERROR: " + e.Message);
                result = false;
            }
            finally
            {
                Disconnect();
            }

            if (result)
            {
                Connect();
                try
                {
                    string sql = "DELETE FROM Bus WHERE numberPlate='@id';";
                    SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                    cmd_SQL.Parameters.AddWithValue("@id", id);
                    cmd_SQL.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    log.Error("ERROR: " + e.Message);
                    result = false;
                }
                finally
                {
                    Disconnect();
                }

            }
            return result;
        }

        public bool UpdateBus(string id, Bus bus)
        {
            bool result = true;
            Connect();

            try
            {
                string sql = "UPDATE Bus SET mileage=@Mileage, TechnicalStatus=@Status where numberPlate='@id'";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@id", id);
                cmd_SQL.Parameters.AddWithValue("@Mileage", bus.Mileage);
                cmd_SQL.Parameters.AddWithValue("@Status", bus.Status);
                cmd_SQL.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                log.Error("ERROR: " + e.Message);
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;

        }

    }
}