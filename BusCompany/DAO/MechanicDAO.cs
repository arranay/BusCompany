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
            string query = "SELECT*FROM Employees INNER JOIN Mechanic ON Mechanic.id=Employees.personnelNumber where Employees.personnelNumber=@id";
            SqlCommand commandRead = new SqlCommand(query, Connection);
            commandRead.Parameters.AddWithValue("@id", id);
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
                    mechanic.Prize = Convert.ToDecimal(reader["Prize"]);
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
                string sql = "DELETE FROM Service WHERE idEmployees='@id';";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@id", id);
                cmd_SQL.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                log.Error("ERROR: " + e.Message);
                result = false;
            }
            finally
            {
                Disconnect();
            }

            Connect();
            if (result)
            {
                try
                {
                    string sql = "DELETE FROM Mechanic WHERE id =@id; DELETE FROM Employees WHERE personnelNumber =@id";
                    SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                    cmd_SQL.Parameters.AddWithValue("@id", id);
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

        public bool EditMechanic(int id, Mechanic mechanic)
        {
            Employees employees = new Employees(mechanic.LastName, mechanic.FirstName, mechanic.MiddleName,
                                                                        mechanic.Experience, mechanic.Salary);
            EmployeesDAO employeesDAO = new EmployeesDAO();
            bool result = false;

            if (employeesDAO.EditEmployees(id, employees))
            {
                result = true;
                Connect();
                try
                {
                    string sql = "UPDATE mechanic " +
                        "SET qualification=@qualification WHERE id=@id";
                    SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                    cmd_SQL.Parameters.AddWithValue("@id", id);
                    cmd_SQL.Parameters.AddWithValue("@qualification", mechanic.Qualification);
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

        public bool AddMechanic(Mechanic mechanic, int id)
        {

            Connect();
            try
            {
                string sql = "INSERT INTO Mechanic" +
                    "(id, Qualification) VALUES (@id, @Qualification)";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@id", id);
                cmd_SQL.Parameters.AddWithValue("@Qualification", mechanic.Qualification);
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