using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusCompany.Models;

namespace BusCompany.DAO
{
    public class RouteDAO : ClassDAO
    {
        public List<Route> GetAllRoute()
        {
            Connect();
            log4net.Config.DOMConfigurator.Configure();

            log.Info("Вызывается метод который возвращает список всех маршрутов.");

            List<Route> routelList = new List<Route>();

            SqlCommand commandRead = new SqlCommand("SELECT*FROM Route;", Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Route route = new Route();
                        route.Id = Convert.ToInt32(reader["id"]);
                        route.RouteName = Convert.ToString(reader["RouteName"]);
                        route.NumberOfHult = Convert.ToInt32(reader["NumberOfHult"]);
                        route.ApprovedStatus = Convert.ToBoolean(reader["ApprovedStatus"]);
                        routelList.Add(route);
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

            return routelList;
        }

        public Route GetById(int id)
        {
            Connect(); Route route= new Route();
            string query = "SELECT*FROM Route where id=" + id;
            SqlCommand commandRead = new SqlCommand(query, Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        route.Id = Convert.ToInt32(reader["id"]);
                        route.RouteName = Convert.ToString(reader["RouteName"]);
                        route.NumberOfHult = Convert.ToInt32(reader["NumberOfHult"]);
                        route.ApprovedStatus = Convert.ToBoolean(reader["ApprovedStatus"]);
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
            return route;
        }

        public List<Hult> GetHultById(int id)
        {
            Connect();
            log4net.Config.DOMConfigurator.Configure();

            log.Info("Вызывается метод который возвращает список всех остановок на маршруте.");

            List<Hult> hultlList = new List<Hult>();
            string query = "SELECT*FROM RoteHult INNER JOIN Hult " +
                "ON Hult.id=RoteHult.Id_Hult where Id_Route=" + id + "  ORDER BY RoteHult.routeNumber ASC;";

            SqlCommand commandRead = new SqlCommand(query, Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Hult hult = new Hult();
                        hult.HultName = Convert.ToString(reader["hultName"]);
                        hult.RoutNumber = Convert.ToInt32(reader["RouteNumber"]);
                        hultlList.Add(hult);
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

            return hultlList;
        }

        public bool DeleteRoute(int id)
        {

            bool result = true;
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который удаляет маршрут");
            Connect();
            try
            {
                string sql = "DELETE FROM RoteHult WHERE Id_Route =" + id + "; DELETE FROM Route WHERE Id =" + id;
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