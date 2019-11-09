using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusCompany.Models;

namespace BusCompany.DAO
{
    public class EmployeesDAO: ClassDAO
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
                    empl.DateOfBirth = Convert.ToString(reader["DateOfBirth"]);
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
            string query = "SELECT*FROM Employees where personnelNumber=" + id;
            SqlCommand commandRead = new SqlCommand(query, Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    empl.PersonnelNumber = Convert.ToInt32(reader["personnelNumber"]);
                    empl.LastName = Convert.ToString(reader["LastName"]);
                    empl.FirstName = Convert.ToString(reader["FirstName"]);
                    empl.MiddleName = Convert.ToString(reader["MiddleName"]);
                    empl.DateOfBirth = Convert.ToString(reader["DateOfBirth"]);
                    empl.Experience = Convert.ToInt32(reader["Experience"]); ;
                    empl.Salary = Convert.ToDecimal(reader["Salary"]);
                    empl.Position = Convert.ToString(reader["Position"]);
                }
            }
            reader.Close();
            Disconnect();

            return empl;
        }

        public bool AddEmployees(Employees employees)
        {
            bool result = true;
            Connect();

            try
            {
                string sql = "INSERT INTO Employees" +
                    " (LastName, FirstName, MiddleName,DateOfBirth,Experience,Salary,Position)" +
                    " VALUES (@LastName, @FirstName, @MiddleName,@DateOfBirth,@Experience,@Salary,@Position)";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@LastName", employees.LastName);
                cmd_SQL.Parameters.AddWithValue("@FirstName", employees.FirstName);
                cmd_SQL.Parameters.AddWithValue("@MiddleName", employees.MiddleName);
                cmd_SQL.Parameters.AddWithValue("@DateOfBirth", employees.DateOfBirth);
                cmd_SQL.Parameters.AddWithValue("@Experience", employees.Experience);
                cmd_SQL.Parameters.AddWithValue("@Salary", employees.Salary);
                cmd_SQL.Parameters.AddWithValue("@Position", employees.Position);
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

        public bool EditEmployees(int id, Employees employees)
        {
            bool result = true;
            Connect();

            try
            {
                string sql = "UPDATE Employees " +
                    "SET LastName=@LastName, FirstName=@FirstName, MiddleName=@MiddleName,DateOfBirth=@DateOfBirth," +
                    "Experience=@Experience,Salary=@Salary,Position=@Position WHERE personnelNumber=" + id;
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@LastName", employees.LastName);
                cmd_SQL.Parameters.AddWithValue("@FirstName", employees.FirstName);
                cmd_SQL.Parameters.AddWithValue("@MiddleName", employees.MiddleName);
                cmd_SQL.Parameters.AddWithValue("@DateOfBirth", employees.DateOfBirth);
                cmd_SQL.Parameters.AddWithValue("@Experience", employees.Experience);
                cmd_SQL.Parameters.AddWithValue("@Salary", employees.Salary);
                cmd_SQL.Parameters.AddWithValue("@Position", employees.Position);
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

        public bool DeleteEmployees(int id)
        {
            bool result = true;
            Connect();
            try
            {
                string sql = "DELETE FROM Employees WHERE personnelNumber =" + id;
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

        public int Sum(int x, int y)
        {
            return x + y;
        }


    }
}