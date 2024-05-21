using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SearchAPI.Model
{
    public class Res
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Dictionary<string, object>> Data { get; set; }
        public Res(int status,string massage, List<Dictionary<string, object>> data)
        {
            this.status = status;
            this.message = massage;
            this.Data = data;
        }
    }
}
