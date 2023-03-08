namespace KrisInfoRazor.Models
{
    public class KrisInfoResponse
    {
        public int Identifier { get; set; }
        public string PushMessage { get; set; }
        public DateTime Published { get; set; }
        public List<Area> Area { get; set; }
    }
}
