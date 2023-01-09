using System.Data.SqlClient;
using WebApplication3.Models;

namespace WebApplication3.Service
{
    public class EmployeeService
    {
        private SqlConnection GetConnection(string _connectionStrimg)
        {
            return new SqlConnection(_connectionStrimg);

        }

        public IEnumerable<Employee> GetEmployee(string _connectionStrimg)
        {
            List<Employee> employees = new List<Employee>();
            string str = "select * from dbo.Test";

            SqlConnection con = GetConnection(_connectionStrimg);
            con.Open();

            SqlCommand cmd = new SqlCommand(str, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Employee employee = new Employee()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Phone = reader.GetString(2)

                    };
                    employees.Add(employee);
                }
            }
            con.Close();

            return employees;

        }
    }
}