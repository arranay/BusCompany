using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusCompany.Models;

namespace BusCompany.DAO
{
    public class DriverDAO : ClassDAO
    {

        public Driver GetById(int id)
        {
            Connect(); Driver driver = new Driver();
            string query = "SELECT*FROM Employees INNER JOIN Driver ON Driver.id=Employees.personnelNumber where Employees.personnelNumber=@id";
            SqlCommand commandRead = new SqlCommand(query, Connection);
            commandRead.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader reader = commandRead.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    driver.PersonnelNumber = Convert.ToInt32(reader["personnelNumber"]);
                    driver.LastName = Convert.ToString(reader["LastName"]);
                    driver.FirstName = Convert.ToString(reader["FirstName"]);
                    driver.MiddleName = Convert.ToString(reader["MiddleName"]);
                    driver.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    driver.Experience = Convert.ToInt32(reader["Experience"]); ;
                    driver.Salary = Convert.ToDecimal(reader["Salary"]);
                    driver.Position = Convert.ToString(reader["Position"]);
                    driver.Categories = Convert.ToString(reader["categories"]);
                    driver.RightsDate = Convert.ToDateTime(reader["RightsDate"]);
                    driver.OnRoute = Convert.ToBoolean(reader["OnRoute"]);
                    driver.Prize = Convert.ToDecimal(reader["Prize"]);
                }
            }
            reader.Close();
            Disconnect();

            return driver;
        }

        public bool DeleteDriver(int id)
        {
            bool result = true;
            Connect();
            try
            {
                string sql = "DELETE FROM Driver WHERE id =@id; DELETE FROM Employees WHERE personnelNumber =@id";
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

        public bool EditDriver(int id, Driver driver)
        {
            Employees employees = new Employees(driver.LastName, driver.FirstName, driver.MiddleName,
                                                                        driver.Experience, driver.Salary);
            EmployeesDAO employeesDAO = new EmployeesDAO();
            bool result = false;

            if (employeesDAO.EditEmployees(id, employees))
            {
                result = true;
                Connect();
                try
                {
                    string sql = "UPDATE Driver " +
                        "SET categories=@categories, rightsDate=@rightsDate WHERE id=@id";
                    SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                    cmd_SQL.Parameters.Add(new SqlParameter("@id", id));
                    cmd_SQL.Parameters.AddWithValue("@categories", driver.Categories);
                    cmd_SQL.Parameters.AddWithValue("@rightsDate", driver.RightsDate);
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
            }
            return result;
        }

        public bool AddDriver(Driver driver, int id)
        {

                Connect();
                try
                {
                    string sql = "INSERT INTO Driver" +
                        "(id, categories, rightsDate,onRoute)" +
                        " VALUES (@id, @categories, @rightsDate, @onRoute)";
                    SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                    cmd_SQL.Parameters.AddWithValue("@id", id);
                    cmd_SQL.Parameters.AddWithValue("@categories", driver.Categories);
                    cmd_SQL.Parameters.AddWithValue("@rightsDate", driver.RightsDate);
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