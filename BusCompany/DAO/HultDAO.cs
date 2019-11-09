using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusCompany.Models;


namespace BusCompany.DAO
{
    public class HultDAO : ClassDAO
    {

        public List<Hult> GetAllHult()
        {

            Connect();
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который возвращает список всех остановок.");
            List<Hult> hultlList = new List<Hult>();

            SqlCommand commandRead = new SqlCommand("SELECT*FROM Hult;", Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Hult hult = new Hult();
                        hult.Id = Convert.ToInt32(reader["id"]);
                        hult.HultName = Convert.ToString(reader["hultName"]);
                        hultlList.Add(hult);
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

            return hultlList;
        }

        public bool AddHult(Hult hult)
        {

            bool result = true;
            Connect();
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который добавляет новую остановку");

            try
            {
                string sql = "INSERT INTO Hult (hultName) VALUES (@hultName)";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@hultName", hult.HultName);
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


        public bool DeleteHult(int id)
        {

            bool result = true;
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который удаляет остановку");
            Connect();
            try
            {
                string sql = "DELETE FROM Hult WHERE Id =" + id;
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
