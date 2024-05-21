using LoginApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Interface _passwordHasher;

        public LoginController(IConfiguration configuration, Interface passwordHasher)
        {
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        public JsonResult Login(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return new JsonResult(new Res(400, "Invalid user data"));
            }

            string query = @"SELECT userPassword FROM Users WHERE userName = @user";
            string query2 = @"UPDATE Users SET isActive = 1 WHERE userName = @user";
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("UserCon")))
                {
                    con.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, con))
                    {
                        sqlCommand.Parameters.AddWithValue("@user", user.UserName);
                        string storedPasswordHash = (string)sqlCommand.ExecuteScalar();

                        if (storedPasswordHash == null)
                        {
                            return new JsonResult(new Res(404, "Invalid username or password"));
                        }

                        bool isPasswordValid = _passwordHasher.VerifyPassword(storedPasswordHash, user.Password);

                        if (isPasswordValid)
                        {
                            using (SqlCommand updateCommand = new SqlCommand(query2, con))
                            {
                                updateCommand.Parameters.AddWithValue("@user", user.UserName);
                                updateCommand.ExecuteNonQuery();
                            }
                            return new JsonResult(new Res(200, "Login Success"));
                        }
                        else
                        {
                            return new JsonResult(new Res(404, "Invalid username or password"));
                        }
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

