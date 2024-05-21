namespace LoginApi.Models
{
    public class Res
    {
        public int Status { get; set; }
        public string Massenge { get; set; }

        public Res(int status, string mesenge)
        {
            this.Status = status;
            this.Massenge = mesenge;
        }
    }
}
