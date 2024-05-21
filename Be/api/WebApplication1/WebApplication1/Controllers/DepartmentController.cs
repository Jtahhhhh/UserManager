using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Get /department
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.department";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource)) 
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand(query,sqlConnection)) 
                {
                    sqlDataReader= sqlCommand.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                return new JsonResult(dt);
            }
        }

        //Post /department/:id
        [HttpPost]
        public JsonResult Post(Department department)
        {
            string query = @"insert into dbo.department values(@department)";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@department",department.Name);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                return new JsonResult("Added successfull");
            }
        }

        //Put /department/:id
        [HttpPut]
        public JsonResult Put(Department department)
        {
            string query = @"update dbo.department set departmentName= @departmentName where departmentId = @departmentId";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@department", department.Name);
                    sqlCommand.Parameters.AddWithValue("@department", department.Id);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                return new JsonResult("Updated successfull");
            }
        }

        //Delete /department/:id
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            string query = @"delete from dbo.department where departmentId = @departmentId";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@departmentId", id);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                return new JsonResult("delete successful");
            }
        }
    }
}
