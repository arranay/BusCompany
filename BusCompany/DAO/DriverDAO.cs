using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusCompany.Models;

namespace BusCompany.DAO
{
    public class DriverDAO : EmployeesDAO
    {
        public List<Driver> GetAllDriver()
        {
            Connect();
            List<Driver> driver = new List<Driver>();
            string query = "SELECT*FROM Employees, Driver where Driver.id=Employees.personnelNumber;";
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
                    dr.DateOfBirth = Convert.ToString(reader["DateOfBirth"]);
                    dr.Experience = Convert.ToInt32(reader["Experience"]); ;
                    dr.Salary = Convert.ToDecimal(reader["Salary"]);
                    dr.Position = Convert.ToString(reader["Position"]);
                    dr.Categories = Convert.ToString(reader["categories"]);
                    dr.RightsDate = Convert.ToString(reader["RightsDate"]);
                    dr.OnRoute = Convert.ToBoolean(reader["OnRoute"]);
                    driver.Add(dr);
                }
            }
            reader.Close();
            Disconnect();

            return driver;
        }

    }
}