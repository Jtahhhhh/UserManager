using LogoutAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace LogoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public LogoutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPut]
        public JsonResult Logout(string user)
        {
            var query = "exec Logout @name";
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserCon")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", user);
                        int result = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        
                        if (result > 0)
                        {
                            return new JsonResult(new Res("200", "Success"));
                        }
                        else
                        {
                            return new JsonResult(new Res("404", "User not found"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new Res("500", "Internal Server Error: " + ex.Message));
            }
        }
    }
}


