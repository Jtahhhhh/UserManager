using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Get /employee
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.employee";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlDataReader = sqlCommand.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                return new JsonResult(dt);
            }
        }

        //Post /employee/:id
        [HttpPost]
        public JsonResult Post(Employee employee)
        {
            string query = @"INSERT INTO [dbo].[employee]
                            VALUES(@name, @departmentName,getdate()
                                    ,@photo)";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@departmentName", employee.Department);
                    sqlCommand.Parameters.AddWithValue("@name",employee.Name );
                    sqlCommand.Parameters.AddWithValue("@photo", employee.img);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                return new JsonResult(dt);
            }
        }

        //Put /employee/:id
        [HttpPut]
        public JsonResult Put(Employee employee)
        {
            string query = @"
                            UPDATE [dbo].[employee]
                               SET [empName] = @name
	                              ,[department] = @departmentName
                                  ,[dateOfJoin] = @date
                                  ,[photo] = @img
                             WHERE empId= @id
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@departmentName", employee.Department);
                    sqlCommand.Parameters.AddWithValue("@name", employee.Name);
                    sqlCommand.Parameters.AddWithValue("@photo", employee.img);
                    sqlCommand.Parameters.AddWithValue("@id", employee.Id);
                    sqlCommand.Parameters.AddWithValue("@date", employee.DateOfJoin);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                return new JsonResult(dt);
            }
        }

        //Delete /employee/:id
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            string query = @"delete from dbo.employee where empId = @id";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("id", id);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                return new JsonResult(dt);
            }
        }

        

    }
}
