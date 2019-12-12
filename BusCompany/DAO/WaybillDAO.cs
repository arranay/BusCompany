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
            log.Info("Вызывается метод который удаляет запись в таблице Путевых листов");
            WaybillDAO waybillD = new WaybillDAO();
            Waybil waybil = waybillD.GetById(id);
            Connect();
            try
            {
                string sql = "UPDATE Bus SET Status=@Status where numberPlate='" + waybil.BusId + "';";
                sql += "UPDATE Conductor SET onRoute=@onRoute1 where Id=" + waybil.ConductorId + ";";
                sql += "UPDATE Driver SET onRoute=@onRoute2 where Id=" + waybil.DriverId + ";";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@Status", false);
                cmd_SQL.Parameters.AddWithValue("@onRoute1", false);
                cmd_SQL.Parameters.AddWithValue("@onRoute2", false);
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
                    string sql = "DELETE FROM Waybil WHERE Id =" + id;
                    SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
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

        public bool AddWaybil(Waybil waybil)
        {
            bool result = true;
            Connect();
            log.Info("Вызывается метод который добавляет новую запись в таблицу Путевых листов");

            try
            {
                string sql = "INSERT INTO Waybil (RouteId, DriverId, ConductorId, BusId, Date) VALUES (@RouteId, @DriverId, @ConductorId, @BusId, @Date);";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@RouteId", waybil.RoutId);
                cmd_SQL.Parameters.AddWithValue("@DriverId", waybil.DriverId);
                cmd_SQL.Parameters.AddWithValue("@ConductorId", waybil.ConductorId);
                cmd_SQL.Parameters.AddWithValue("@BusId", waybil.BusId);
                cmd_SQL.Parameters.AddWithValue("@Date", waybil.Date);
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
                    string sql = "UPDATE Bus SET Status=@Status where numberPlate='" + waybil.BusId + "';";
                    sql+= "UPDATE Conductor SET onRoute=@onRoute1 where Id=" + waybil.ConductorId + ";";
                    sql += "UPDATE Driver SET onRoute=@onRoute2 where Id=" + waybil.DriverId + ";";
                    SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                    cmd_SQL.Parameters.AddWithValue("@Status", true);
                    cmd_SQL.Parameters.AddWithValue("@onRoute1", true);
                    cmd_SQL.Parameters.AddWithValue("@onRoute2", true);
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

        public List<string> GetAllBus()
        {
            List<string> bus = new List<string>();
            Connect();
            try
            {
                string query = "SELECT*FROM Bus where technicalStatus=1 and Status=0";
                SqlCommand commandRead = new SqlCommand(query, Connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bus.Add(Convert.ToString(reader["numberPlate"]));
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("ERROR: " + e.Message);
            }
            finally
            {
                Disconnect();
            }
            return bus;
        }

        public List<Driver> GetAllDriver()
        {
            List<Driver> drivers = new List<Driver>();
            Connect();
            try
            {
                string query = "SELECT*FROM Driver INNER JOIN Employees ON Driver.id=Employees.personnelNumber where onRoute=0;";
                SqlCommand commandRead = new SqlCommand(query, Connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Driver driver = new Driver();
                        driver.PersonnelNumber = Convert.ToInt32(reader["personnelNumber"]);
                        driver.LastName = Convert.ToString(reader["LastName"]) + Convert.ToString(reader["FirstName"]) + Convert.ToString(reader["categories"]);
                        drivers.Add(driver);

                    }
                }
            }
            catch (Exception e)
            {
                log.Error("ERROR: " + e.Message);
            }
            finally
            {
                Disconnect();
            }
            return drivers;
        }

        public List<Conductor> GetAllConductor()
        {
            List<Conductor> conductors = new List<Conductor>();
            Connect();
            try
            {
                string query = "SELECT*FROM Conductor INNER JOIN Employees ON Conductor.id=Employees.personnelNumber where onRoute=0;";
                SqlCommand commandRead = new SqlCommand(query, Connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Conductor conductor = new Conductor();
                        conductor.PersonnelNumber = Convert.ToInt32(reader["personnelNumber"]);
                        conductor.LastName = Convert.ToString(reader["LastName"]) + Convert.ToString(reader["FirstName"]);
                        conductors.Add(conductor);

                    }
                }
            }
            catch (Exception e)
            {
                log.Error("ERROR: " + e.Message);
            }
            finally
            {
                Disconnect();
            }
            return conductors;
        }

        public List<Route> GetAllRoute()
        {
            List<Route> route = new List<Route>();
            Connect();
            try
            {
                string query = "SELECT*FROM Route where approvedStatus=1";
                SqlCommand commandRead = new SqlCommand(query, Connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Route rout = new Route();
                        rout.Id = Convert.ToInt32(reader["Id"]);
                        rout.RouteName = Convert.ToString(reader["routeName"]);
                        route.Add(rout);
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("ERROR: " + e.Message);
            }
            finally
            {
                Disconnect();
            }
            return route;
        }

        public bool UpdateWaybill(int id, Waybil waybil)
        {
            bool result = true;
            Connect();

            try
            {
                string sql = "UPDATE Waybil SET date=@date,RouteId=@RouteId, " +
                    "DriverId=@DriverId, ConductorId=@ConductorId, BusId=@BusId WHERE id=" + id;
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@date", waybil.Date);
                cmd_SQL.Parameters.AddWithValue("@DriverId", waybil.DriverId);
                cmd_SQL.Parameters.AddWithValue("@ConductorId", waybil.ConductorId);
                cmd_SQL.Parameters.AddWithValue("@BusId", waybil.BusId);
                cmd_SQL.Parameters.AddWithValue("@RouteId", waybil.RoutId);
                cmd_SQL.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error("ERROR: " + e.Message);
            }
            finally
            {
                Disconnect();
            }
            return result;

        }

        public List<Driver> GetAllDriverPlusOnRoat(int id)
        {
            List<Driver> drivers = new WaybillDAO().GetAllDriver();
            Waybil waybil = new WaybillDAO().GetById(id);
            Connect();
            try
            {
                string query = "SELECT*FROM Driver INNER JOIN Employees ON Driver.id=Employees.personnelNumber where Id='" + waybil.DriverId+"'";
                SqlCommand commandRead = new SqlCommand(query, Connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Driver driver = new Driver();
                        driver.PersonnelNumber = Convert.ToInt32(reader["personnelNumber"]);
                        driver.LastName = Convert.ToString(reader["LastName"]) + Convert.ToString(reader["FirstName"]) + Convert.ToString(reader["categories"]);
                        drivers.Add(driver);

                    }
                }
            }
            catch (Exception e)
            {
                log.Error("ERROR: " + e.Message);
            }
            finally
            {
                Disconnect();
            }
            return drivers;
        }

        public List<Conductor> GetAllConductorPlusOnRoat(int id)
        {
            List<Conductor> conductors = new WaybillDAO().GetAllConductor();
            Waybil waybil = new WaybillDAO().GetById(id);
            Connect();
            try
            {
                string query = "SELECT*FROM Conductor INNER JOIN Employees ON Conductor.id=Employees.personnelNumber where Id='" + waybil.ConductorId + "'";
                SqlCommand commandRead = new SqlCommand(query, Connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Conductor conductor = new Conductor();
                        conductor.PersonnelNumber = Convert.ToInt32(reader["personnelNumber"]);
                        conductor.LastName = Convert.ToString(reader["LastName"]) + Convert.ToString(reader["FirstName"]);
                        conductors.Add(conductor);

                    }
                }
            }
            catch (Exception e)
            {
                log.Error("ERROR: " + e.Message);
            }
            finally
            {
                Disconnect();
            }
            return conductors;
        }

        public List<string> GetAllBusPlusOnRoat(int id)
        {
            List<string> busList = new WaybillDAO().GetAllBus();
            Waybil waybil = new WaybillDAO().GetById(id);
            Connect();
            try
            {
                string query = "SELECT*FROM Bus where NumberPlate='" + waybil.BusId+"'";
                SqlCommand commandRead = new SqlCommand(query, Connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        busList.Add(Convert.ToString(reader["NumberPlate"]));
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("ERROR: " + e.Message);
            }
            finally
            {
                Disconnect();
            }
            return busList;
        }


    }
}