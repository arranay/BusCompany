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
                        Service servise= new Service();
                        servise.Id = Convert.ToInt32(reader["id"]);
                        servise.IdBus = Convert.ToString(reader["IdBus"]);
                        servise.IdEmployees = Convert.ToInt16(reader["IdEmployees"]);
                        servise.ServiceDate = Convert.ToDateTime(reader["serviceDate"]);
                        servise.TypeOfWork = Convert.ToString(reader["TypeOfWork"]);
                        servicelList.Add(servise);
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
    }
}