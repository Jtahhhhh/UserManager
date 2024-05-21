using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SearchAPI.Model;
using System.Data;
using System.Xml.Linq;

namespace SearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SearchController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public JsonResult search(Querry q)
        {
            string querry = @"exec search @name,@phone,@address";
            DataTable dt = new DataTable();
            
           if(q.UserName == "" && q.Address == "" && q.Phone =="" && q.Name!="") {
                q.UserName = q.Name;
            }
            try 
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("UserCon")))
                {
                    con.Open();
                    using(SqlCommand cmd = new SqlCommand(querry, con))
                    {
                        cmd.Parameters.AddWithValue("@name",q.UserName);
                        cmd.Parameters.AddWithValue("@phone", q.Phone);
                        cmd.Parameters.AddWithValue("@address", q.Address);

                        using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                        {
                            dt.Load(sqlDataReader);
                            
                        }

                        con.Close();
                        return new JsonResult(new Res(200,"Success", DataTableToList(dt)));
                    }
                }
            }
            catch(Exception ex) 
            {
                return new JsonResult(new Res(500, "Invalid database"+ex.Message,null));
            }           
        }
        private List<Dictionary<string, object>> DataTableToList(DataTable dt)
        {
            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }
            return list;
        }
    }
}
