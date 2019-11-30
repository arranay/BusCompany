using BusCompany.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BusCompany.DAO
{
    public class WaybillDAO : ClassDAO
    {
        public List<Waybil> GetAllWaybil()
        {
            Connect();
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который возвращает список все путевые листы.");

            List<Waybil> waybilList = new List<Waybil>();

            SqlCommand commandRead = new SqlCommand("SELECT*FROM Waybil;", Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Waybil waybil = new Waybil();
                        waybil.Id = Convert.ToInt32(reader["id"]);
                        waybil.RoutId = Convert.ToInt32(reader["RouteId"]);
                        waybil.DriverId = Convert.ToInt32(reader["DriverId"]);
                        waybil.ConductorId = Convert.ToInt32(reader["ConductorId"]);
                        waybil.BusId = Convert.ToString(reader["BusId"]);
                        waybil.Date = Convert.ToDateTime(reader["Date"]);

                        waybil.Route = new RouteDAO().GetById(waybil.RoutId);
                        waybil.Driver = new DriverDAO().GetById(waybil.DriverId);
                        waybil.Conductor = new ConductorDAO().GetById(waybil.ConductorId);
                        waybil.Bus = new BusDAO().GetById(waybil.BusId);
                        waybilList.Add(waybil);
                    }
                }
            }
            catch (SqlException e)
            {
                log.Error("ERROR: " + e.Message);
            }
            finally
            {
                reader.Close();
                Disconnect();
            }

            return waybilList;
        }

        public Waybil GetById(int id)
        {
            Connect(); Waybil waybil = new Waybil();
            string query = "SELECT*FROM Waybil where id=" + id;
            SqlCommand commandRead = new SqlCommand(query, Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            try
            {
            if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                   
                        waybil.Id = Convert.ToInt32(reader["id"]);
                        waybil.RoutId = Convert.ToInt32(reader["RouteId"]);
                        waybil.DriverId = Convert.ToInt32(reader["DriverId"]);
                        waybil.ConductorId = Convert.ToInt32(reader["ConductorId"]);
                        waybil.BusId = Convert.ToString(reader["BusId"]);
                        waybil.Date = Convert.ToDateTime(reader["Date"]);

                        waybil.Route = new RouteDAO().GetById(waybil.RoutId);
                        waybil.Driver = new DriverDAO().GetById(waybil.DriverId);
                        waybil.Conductor = new ConductorDAO().GetById(waybil.ConductorId);
                        waybil.Bus = new BusDAO().GetById(waybil.BusId);
                    }
                }
            }catch (SqlException e)
            {
                log.Error("ERROR: " + e.Message);
            }
            finally
            {
                reader.Close();
                Disconnect();
            }

            return waybil;

        }

        public bool DeleteWaybil(int id)
        {

            bool result = true;
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который удаляет запись в таблице Путевых листов");
            Connect();
            try
            {
                string sql = "DELETE FROM Waybil WHERE Id =" + id;
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                log.Error("ERROR" + e.Message);
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