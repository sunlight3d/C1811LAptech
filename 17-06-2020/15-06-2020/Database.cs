using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _15_06_2020.models;
using System.Data;

namespace _15_06_2020
{
    class Database
    {
        private const string SERVER_NAME = "DESKTOP-7PS7HG8\\SQLEXPRESS";
        private const string DATABASE_NAME = "C1811L";
        private const string USER_NAME = "sa";
        private const string PASSWORD = "";
        private const String CONNECTION_STRING = "Server=DESKTOP-7PS7HG8\\SQLEXPRESS; Database=C1811L;Integrated Security = SSPI;";
        private static Database database;
        private Database() { }
        public static Database SharedInstance() {
            if (database == null)
            {
                database = new Database();
            }
            return database;

        }
        public SqlConnection GetConnection()
        { 
            var connection = new SqlConnection(CONNECTION_STRING);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = this.GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM tblEmployees", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //MessageBox.Show(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
                        Console.WriteLine("haha");
                        var EmployeeName = dataReader.GetValue(1);
                        var Department = dataReader.GetValue(2);
                        var Gender = dataReader.GetValue(3);
                        var Telephone = dataReader.GetValue(4);
                        employees.Add(new Employee() {
                            Id = Convert.ToInt32(dataReader.GetValue(0)),
                            EmployeeName = dataReader.GetValue(1) as string,
                            Department = dataReader.GetValue(2) as string,
                            Gender = dataReader.GetValue(3) as string,
                            Telephone = dataReader.GetValue(4) as string
                        });
                    }
                    dataReader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    return employees;
                }
            }
                return employees;
        }
        public Boolean insertEmployee(Employee employee)
        {
            Boolean result = true;
            using (SqlConnection connection = this.GetConnection())
            {
                try
                {
                    string sql = "INSERT INTO tblEmployees(EmployeeName,Department,Gender,Telephone)" +
                        "VALUES(@EmployeeName,@Department,@Gender,@Telephone)";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 500).Value = employee.EmployeeName;
                    command.Parameters.Add("@Department", SqlDbType.VarChar, 500).Value = employee.Department;
                    command.Parameters.Add("@Gender", SqlDbType.VarChar, 200).Value = employee.Gender;
                    command.Parameters.Add("@Telephone", SqlDbType.VarChar, 300).Value = employee.Telephone;
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                   
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
            return result;
        }
    }
}
