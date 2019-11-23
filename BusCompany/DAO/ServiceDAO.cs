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
            log.Info("Вызывается метод который возвращает список всех остановок.");
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
            log.Info("Вызывается метод который удаляет остановку");
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
    }
}