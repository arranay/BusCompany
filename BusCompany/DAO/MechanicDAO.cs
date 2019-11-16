using BusCompany.Models;
using System;
using System.Data.SqlClient;


namespace BusCompany.DAO
{
    public class MechanicDAO : ClassDAO
    {
        public Mechanic GetById(int id)
        {
            Connect(); Mechanic mechanic = new Mechanic();
            string query = "SELECT*FROM Employees INNER JOIN Mechanic ON Mechanic.id=Employees.personnelNumber where Employees.personnelNumber=" + id;
            SqlCommand commandRead = new SqlCommand(query, Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    mechanic.PersonnelNumber = Convert.ToInt32(reader["personnelNumber"]);
                    mechanic.LastName = Convert.ToString(reader["LastName"]);
                    mechanic.FirstName = Convert.ToString(reader["FirstName"]);
                    mechanic.MiddleName = Convert.ToString(reader["MiddleName"]);
                    mechanic.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    mechanic.Experience = Convert.ToInt32(reader["Experience"]); ;
                    mechanic.Salary = Convert.ToDecimal(reader["Salary"]);
                    mechanic.Position = Convert.ToString(reader["Position"]);
                    mechanic.Qualification = Convert.ToString(reader["Qualification"]);
                }
            }
            reader.Close();
            Disconnect();

            return mechanic;
        }

        public bool DeleteMechanic(int id)
        {
            bool result = true;
            Connect();
            try
            {
                string sql = "DELETE FROM Mechanic WHERE id =" + id+ "; DELETE FROM Employees WHERE personnelNumber =" + id;
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
    }
}