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
                log.Error("ERROR" + e.Message);
            }
            finally
            {
                reader.Close();
                Disconnect();
            }

            return routelList;
        }

    }
}