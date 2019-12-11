using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                        GetCountHult(route.Id);
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
                        GetCountHult(route.Id);
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
                        hult.Id = Convert.ToInt32(reader["Id_Hult"]);
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

        public bool AddRout(Route route)
        {
            Connect();
            log.Info("Вызывается метод который добавляет новый маршрут");

            try
            {
                string sql = "INSERT INTO Route (routeName, numberOfHult, approvedStatus) " +
                    "VALUES (@routeName, @numberOfHult, @approvedStatus)";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@routeName", route.RouteName);
                cmd_SQL.Parameters.AddWithValue("@numberOfHult", 0);
                cmd_SQL.Parameters.AddWithValue("@approvedStatus",false);
                cmd_SQL.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                log.Error("ERROR" + e.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }
            return true;
        }

        public bool UpdateRoute(int id, bool status)
        {
            bool result = true;

            try
            {
                Connect();
                string query = "Select COUNT(*) From Waybil WHERE routeId=" + id;
                SqlCommand commandRead = new SqlCommand(query, Connection);
                commandRead.ExecuteNonQuery();
                int count = Convert.ToInt32(commandRead.ExecuteScalar());
                if (count > 0) return false;
                
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

            try
            {
                Connect();
                string sql = "UPDATE Route SET approvedStatus=@approvedStatus WHERE id=" + id;
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@approvedStatus", status);
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

        public bool AddHult(int id, int hultId)
        {
            List<Hult> hultList = new RouteDAO().GetHultById(id);
            int count = hultList.Count();

            bool result = true;

            log.Info("Вызывается метод который добавляет остановку на маршрут");

            try
            {
                Connect();
                string sql = "INSERT INTO RoteHult (Id_Hult, Id_Route, routeNumber) " +
                    "VALUES (@Id_Hult, @Id_Route, @routeNumber)";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@Id_Hult", hultId);
                cmd_SQL.Parameters.AddWithValue("@Id_Route", id);
                cmd_SQL.Parameters.AddWithValue("@routeNumber", count + 1);
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

            if (result)
            {
            //увеличить кол-во остановок
                        try
                        {
                            Connect();
                            string sql = "UPDATE Route SET numberOfHult=@numberOfHult WHERE id=" + id;
                            SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                            cmd_SQL.Parameters.AddWithValue("@numberOfHult", count+1);
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
            }
            
            return result;
        }


        public List<Hult> GetHultWhithout(int id)
        {
            List<Hult> hultList = new RouteDAO().GetHultById(id);
            Connect();
            log4net.Config.DOMConfigurator.Configure();

            log.Info("Вызывается метод который возвращает список всех остановок на маршруте.");

            List<Hult> hultlList = new List<Hult>();
            string query = "SELECT*FROM Hult;";

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
                        hult.Id = Convert.ToInt32(reader["Id"]);
                        bool flag = true;
                        foreach (Hult h in hultList)
                        {
                            if (hult.Id == h.Id) flag=false;
                        }
                        if(flag) hultlList.Add(hult);
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

        private int GetCountHult(int id)
        {
            int count = 0;
            bool result = true;
            try
            {
                Connect();
                string query = "Select COUNT(*) From RoteHult WHERE id_route=" + id;
                SqlCommand commandRead = new SqlCommand(query, Connection);
                commandRead.ExecuteNonQuery();
                count = Convert.ToInt32(commandRead.ExecuteScalar());
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

            if (result)
            {
                try
                {
                    Connect();
                    string query = "UPDATE Route SET numberOfHult=@numberOfHult WHERE id=" + id;
                    SqlCommand cmd_SQL = new SqlCommand(query, Connection);
                    cmd_SQL.Parameters.AddWithValue("@numberOfHult", count);
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

            }
            return count;
        }

    }
}