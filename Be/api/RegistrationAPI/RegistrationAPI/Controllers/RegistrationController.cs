using LoginApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RegistrationAPI.Models;

namespace RegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Interface _iPassWordHasher;
        public RegistrationController(IConfiguration configuration, Interface iPassword)
        {
            _configuration = configuration;
            _iPassWordHasher = iPassword;
        }
        [HttpPost]
        public JsonResult registration(Register register)
        {
            string query = "exec check_and_register @name, @pass, @phone, @address";
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("UserCon").ToString()))
                {
                    con.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, con))
                    {
                        // Use parameterized queries to avoid SQL injection
                        sqlCommand.Parameters.AddWithValue("@name", register.UserName);
                        sqlCommand.Parameters.AddWithValue("@pass", _iPassWordHasher.Hash(register.Password));
                        sqlCommand.Parameters.AddWithValue("@phone", register.PhoneNum);
                        sqlCommand.Parameters.AddWithValue("@address", register.Address);

                        int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        con.Close();

                        if (result > 0)
                            return new JsonResult(new Res(201, "Create Success"));
                        else
                            return new JsonResult(new Res(422, "User already exists"));
                    }
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new Res(500, "Internal Server Error: " + ex.Message));
            }
        }

    }
}
