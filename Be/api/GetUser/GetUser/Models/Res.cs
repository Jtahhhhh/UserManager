namespace GetUser.Models
{
    public class Res
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<Dictionary<string, object>> Data { get; set; }

        public Res(int status, string message, List<Dictionary<string, object>> data)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }
    }
}
