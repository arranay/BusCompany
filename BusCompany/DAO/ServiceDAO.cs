using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusCompany.Models;

namespace BusCompany.DAO
{
    public class ServiceDAO : ClassDAO
    {
        public List<Service> GetAllService()
        {
            
            Connect();
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который возвращает список всех записей из таблицы Сервис.");
            List<Service> servicelList = new List<Service>();
            SqlCommand commandRead = new SqlCommand("SELECT*FROM Service;", Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Service service= new Service();
                        service.Id = Convert.ToInt32(reader["id"]);
                        service.IdBus = Convert.ToString(reader["IdBus"]);
                        service.IdEmployees = Convert.ToInt16(reader["IdEmployees"]);
                        service.ServiceDate = Convert.ToDateTime(reader["serviceDate"]);
                        service.TypeOfWork = Convert.ToString(reader["TypeOfWork"]);
                        service.Bus = new BusDAO().GetById(service.IdBus);
                        service.Employees = new EmployeesDAO().GetById(service.IdEmployees);
                        servicelList.Add(service);
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

            return servicelList;
        }

        public Service GetById(int id)
        {
            Connect(); Service service = new Service();
            string query = "SELECT*FROM Service where id=" + id;
            SqlCommand commandRead = new SqlCommand(query, Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    service.Id = Convert.ToInt32(reader["id"]);
                    service.IdBus = Convert.ToString(reader["IdBus"]);
                    service.IdEmployees = Convert.ToInt16(reader["IdEmployees"]);
                    service.ServiceDate = Convert.ToDateTime(reader["serviceDate"]);
                    service.TypeOfWork = Convert.ToString(reader["TypeOfWork"]);
                    service.Bus = new BusDAO().GetById(service.IdBus);
                    service.Employees = new EmployeesDAO().GetById(service.IdEmployees);
                }
            }
            reader.Close();
            Disconnect();

            return service;

        }

         public bool DeleteService(int id)
        {

            bool result = true;
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который удаляет запись в таблице Сервис");
            Connect();
            try
            {
                string sql = "DELETE FROM Service WHERE Id =" + id;
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

        public bool AddService(Service service)
        {
            bool result = true;
            Connect();
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который добавляет новую запись в таблицу Сервис");

            try
            {
                string sql = "INSERT INTO Service (IdBus, IdEmployees, ServiceDate, TypeOfWork) VALUES (@IdBus, @IdEmployees, @ServiceDate, @TypeOfWork); " +
                    "Update Bus Set status=1 where numberPlate=@IdBus;";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@IdBus", service.IdBus);
                cmd_SQL.Parameters.AddWithValue("@IdEmployees", service.IdEmployees);
                cmd_SQL.Parameters.AddWithValue("@ServiceDate", service.ServiceDate);
                cmd_SQL.Parameters.AddWithValue("@TypeOfWork", service.TypeOfWork);
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

        public List<String> GetAllBus()
        {
            List<String> bus = new List<string>();
            Connect();
            try
            {
                string query = "SELECT*FROM Bus where status=0";
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

    }
}