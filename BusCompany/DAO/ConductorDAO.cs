using BusCompany.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BusCompany.DAO
{
    public class ConductorDAO : ClassDAO
    {
        public Conductor GetById(int id)
        {
            Connect(); Conductor conductor = new Conductor();
            string query = "SELECT*FROM Employees INNER JOIN Conductor ON Conductor.id=Employees.personnelNumber where Employees.personnelNumber=" + id;
            SqlCommand commandRead = new SqlCommand(query, Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    conductor.PersonnelNumber = Convert.ToInt32(reader["personnelNumber"]);
                    conductor.LastName = Convert.ToString(reader["LastName"]);
                    conductor.FirstName = Convert.ToString(reader["FirstName"]);
                    conductor.MiddleName = Convert.ToString(reader["MiddleName"]);
                    conductor.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    conductor.Experience = Convert.ToInt32(reader["Experience"]); ;
                    conductor.Salary = Convert.ToDecimal(reader["Salary"]);
                    conductor.Position = Convert.ToString(reader["Position"]);
                    conductor.OnRoute = Convert.ToBoolean(reader["OnRoute"]);
                }
            }
            reader.Close();
            Disconnect();

            return conductor;
        }

        public bool DeleteConductor(int id)
        {
            bool result = true;
            Connect();
            try
            {
                string sql = "DELETE FROM Conductor WHERE id =" + id + "; DELETE FROM Employees WHERE personnelNumber =" + id;
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        public bool AddConductor(int id)
        {
            Connect();
            try
            {
                string sql = "INSERT INTO Conductor" +
                    "(id, onRoute) VALUES (@id, @onRoute)";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@id", id);
                cmd_SQL.Parameters.AddWithValue("@onRoute", false);
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
    }
}