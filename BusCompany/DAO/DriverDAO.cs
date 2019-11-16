using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusCompany.Models;

namespace BusCompany.DAO
{
    public class DriverDAO : ClassDAO
    {
        public List<Driver> GetAllDriver()
        {
            Connect();
            List<Driver> driver = new List<Driver>();
            string query = "SELECT*FROM Employees INNER JOIN Driver ON Driver.id=Employees.personnelNumber";
            SqlCommand commandRead = new SqlCommand(query, Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Driver dr = new Driver();
                    dr.PersonnelNumber = Convert.ToInt32(reader["personnelNumber"]);
                    dr.LastName = Convert.ToString(reader["LastName"]);
                    dr.FirstName = Convert.ToString(reader["FirstName"]);
                    dr.MiddleName = Convert.ToString(reader["MiddleName"]);
                    dr.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    dr.Experience = Convert.ToInt32(reader["Experience"]); ;
                    dr.Salary = Convert.ToDecimal(reader["Salary"]);
                    dr.Position = Convert.ToString(reader["Position"]);
                    dr.Categories = Convert.ToString(reader["categories"]);
                    dr.RightsDate = Convert.ToDateTime(reader["RightsDate"]);
                    dr.OnRoute = Convert.ToBoolean(reader["OnRoute"]);
                    driver.Add(dr);
                }
            }
            reader.Close();
            Disconnect();

            return driver;
        }

        public Driver GetById(int id)
        {
            Connect(); Driver driver = new Driver();
            string query = "SELECT*FROM Employees INNER JOIN Driver ON Driver.id=Employees.personnelNumber where Employees.personnelNumber=" + id;
            SqlCommand commandRead = new SqlCommand(query, Connection);
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
                }
            }
            reader.Close();
            Disconnect();

            return driver;
        }
    }
}