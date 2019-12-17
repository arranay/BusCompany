using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusCompany.Models;

namespace BusCompany.DAO
{
    public class EmployeesDAO : ClassDAO
    {
        public List<Employees> GetAllEmployees()
        {
            Connect();
            List<Employees> employees = new List<Employees>();

            SqlCommand commandRead = new SqlCommand("SELECT*FROM Employees", Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employees empl = new Employees();
                    empl.PersonnelNumber = Convert.ToInt32(reader["personnelNumber"]);
                    empl.LastName = Convert.ToString(reader["LastName"]);
                    empl.FirstName = Convert.ToString(reader["FirstName"]);
                    empl.MiddleName = Convert.ToString(reader["MiddleName"]);
                    empl.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    empl.Experience = Convert.ToInt32(reader["Experience"]); ;
                    empl.Salary = Convert.ToDecimal(reader["Salary"]);
                    empl.Position = Convert.ToString(reader["Position"]);
                    employees.Add(empl);
                }
            }
            reader.Close();
            Disconnect();

            return employees;
        }

        public Employees GetById(int id)
        {
            Connect(); Employees empl = new Employees();
            string query = "SELECT*FROM Employees where personnelNumber=@id";
            SqlCommand commandRead = new SqlCommand(query, Connection);
            commandRead.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader reader = commandRead.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    empl.PersonnelNumber = Convert.ToInt32(reader["personnelNumber"]);
                    empl.LastName = Convert.ToString(reader["LastName"]);
                    empl.FirstName = Convert.ToString(reader["FirstName"]);
                    empl.MiddleName = Convert.ToString(reader["MiddleName"]);
                    empl.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    empl.Experience = Convert.ToInt32(reader["Experience"]); ;
                    empl.Salary = Convert.ToDecimal(reader["Salary"]);
                    empl.Position = Convert.ToString(reader["Position"]);
                    empl.Prize = Convert.ToDecimal(reader["Prize"]);
                }
            }
            reader.Close();
            Disconnect();

            return empl;
        }

        public List<String> GetAllQualification()
        {
            List<String> qualification = new List<string>();
            Connect();
            try
            {
                string query = "SELECT*FROM Qualification";
                SqlCommand commandRead = new SqlCommand(query, Connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        qualification.Add(Convert.ToString(reader["Name"]));

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
            return qualification;
        }

        public int AddEmployees(Employees employees)
        {
            int result = 0;
            Connect();
            try
            {
                string sql = "INSERT INTO Employees" +
                    " (LastName, FirstName, MiddleName,DateOfBirth,Experience,Salary,Position,Prize)" +
                    " VALUES (@LastName, @FirstName, @MiddleName,@DateOfBirth,@Experience,@Salary,@Position,@Prize)";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@LastName", employees.LastName);
                cmd_SQL.Parameters.AddWithValue("@FirstName", employees.FirstName);
                cmd_SQL.Parameters.AddWithValue("@MiddleName", employees.MiddleName);
                cmd_SQL.Parameters.AddWithValue("@DateOfBirth", employees.DateOfBirth);
                cmd_SQL.Parameters.AddWithValue("@Experience", employees.Experience);
                cmd_SQL.Parameters.AddWithValue("@Salary", employees.Salary);
                cmd_SQL.Parameters.AddWithValue("@Position", employees.Position);
                cmd_SQL.Parameters.AddWithValue("@Prize", 0);
                cmd_SQL.ExecuteNonQuery();
                cmd_SQL.CommandText = "SELECT @@IDENTITY";
                result = Convert.ToInt32(cmd_SQL.ExecuteScalar());
            }
            catch (Exception e)
            {
                log.Error("ERROR: " + e.Message);
                result = 0;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        public bool EditEmployees(int id, Employees employees)
        {
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который изменяет данные о работнике.");
            bool result = true;
            Connect();

            try
            {
                string sql = "UPDATE Employees " +
                    "SET LastName=@LastName, FirstName=@FirstName, MiddleName=@MiddleName," +
                    "Experience=@Experience,Salary=@Salary WHERE personnelNumber=@id";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.Add(new SqlParameter("@id", id));
                cmd_SQL.Parameters.AddWithValue("@LastName", employees.LastName);
                cmd_SQL.Parameters.AddWithValue("@FirstName", employees.FirstName);
                cmd_SQL.Parameters.AddWithValue("@MiddleName", employees.MiddleName);
                cmd_SQL.Parameters.AddWithValue("@Experience", employees.Experience);
                cmd_SQL.Parameters.AddWithValue("@Salary", employees.Salary);
                cmd_SQL.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                log.Error("ERROR" + e.Message);
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        public bool DeleteEmployees(int id)
        {
            bool result = true;
            Connect();
            try
            {
                string sql = "DELETE FROM Employees WHERE personnelNumber = @id";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.Add(new SqlParameter("@id", id));
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

        public List<String> GetAllPosition()
        {
            List<String> position = new List<string>();
            Connect();
            try
            {
                string query = "SELECT*FROM Position";
                SqlCommand commandRead = new SqlCommand(query, Connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        position.Add(Convert.ToString(reader["Name"]));

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
            return position;
        }

        public List<String> GetAllCategories()
        {
            List<String> categories = new List<string>();
            Connect();
            try
            {
                string query = "SELECT*FROM Categories";
                SqlCommand commandRead = new SqlCommand(query, Connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        categories.Add(Convert.ToString(reader["Name"]));

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
            return categories;
        }

        public bool AwardPrize(decimal prize, int id)
        {
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Вызывается метод который назначает рабюотнику премию.");
            bool result = true;
            Connect();
            try
            {
                string sql = "UPDATE Employees " +
                    "SET Prize=@Prize WHERE personnelNumber=@id";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.Add(new SqlParameter("@id", id));
                cmd_SQL.Parameters.AddWithValue("@Prize", prize);
                cmd_SQL.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                log.Error("ERROR" + e.Message);
            }
            finally
            {
                Disconnect();
            }
            return result;

        }

    }
}