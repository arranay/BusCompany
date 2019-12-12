using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusCompany.Models;

namespace BusCompany.DAO
{
    public class UsersDAO : ClassDAO
    {
        public List<Users> GetAllUser()
        {
            ConnectUsers();
            log.Info("Вызывается метод который возвращает список всех пользователей.");
            List<Users> users = new List<Users>();
            bool result = true;
            SqlCommand commandRead = new SqlCommand("SELECT*FROM AspNetUserRoles " +
                "JOIN AspNetUsers ON AspNetUserRoles.UserId=AspNetUsers.Id " +
                "   JOIN AspNetRoles ON AspNetUserRoles.RoleId=AspNetRoles.Id;", Connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Users user = new Users();
                        user.Id= Convert.ToString(reader["id"]);
                        user.Login = Convert.ToString(reader["Email"]);
                        user.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        user.Role = Convert.ToString(reader["Name"]);
                        user.UserName = Convert.ToString(reader[("UserName")]);
                        users.Add(user);
                    }
                }
            }
            catch (SqlException e)
            {
                log.Error("ERROR" + e.Message);
                result = false;
            }
            finally
            {
                reader.Close();
                DisconnectUsers();
            }

            if (result)
            {
                ConnectUsers();
                commandRead = new SqlCommand("SELECT*FROM AspNetUsers;", Connection);
                reader = commandRead.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = true;
                            Users user = new Users();
                            user.Id = Convert.ToString(reader["id"]);
                            user.Login = Convert.ToString(reader["Email"]);
                            user.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                            user.UserName = Convert.ToString(reader[("UserName")]);
                            foreach (Users u in users)
                            {
                                if (u.Id == user.Id) result = false;
                            }
                            if (result) users.Add(user);
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
                    DisconnectUsers();
                }

            }

            return users;
        }



        public List<Role> GetAllRole()
        {
            List<Role> roles = new List<Role>();
            ConnectUsers();
            try
            {
                string query = "SELECT*FROM AspNetRoles";
                SqlCommand commandRead = new SqlCommand(query, Connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Role role = new Role();
                        role.Id = Convert.ToString(reader["Id"]);
                        role.Name = Convert.ToString(reader["Name"]);
                        roles.Add(role);
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("ERROR: " + e.Message);
            }
            finally
            {
                DisconnectUsers();
            }
            return roles;
        }

        public bool AddRole(Users user)
        {
            bool result = true;
            ConnectUsers();
            log.Info("Вызывается метод который назначает пользователю роль");

            try
            {
                string sql = "INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES (@UserId, @RoleId)";
                SqlCommand cmd_SQL = new SqlCommand(sql, Connection);
                cmd_SQL.Parameters.AddWithValue("@UserId", user.Id);
                cmd_SQL.Parameters.AddWithValue("@RoleId", user.Role);
                cmd_SQL.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                log.Error("ERROR" + e.Message);
                result = false;
            }
            finally
            {
                DisconnectUsers();
            }
            return result;
        }
    }
}