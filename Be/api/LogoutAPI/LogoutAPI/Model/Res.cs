namespace LogoutAPI.Model
{
    public class Res
    {
        public string Status { get; set; }
        public string Messenger { get; set; }
        public Res(string status, string messenger)
        {
            Status = status;
            Messenger = messenger;
        }
    }
}
