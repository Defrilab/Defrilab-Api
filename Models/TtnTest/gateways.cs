namespace ReaiotBackend.Models.TtnTest
{
     public class gateways : BaseModel
    {
        public  string gtw_id { get; set; }
        public int timestamp { get; set; }
        public  string time { get; set; }
        public int channel { get; set; }
        public int rssi { get; set; }
        public int snr { get; set; }
        public int rf_chain { get; set; }
        public  double latitude { get; set; }
        public  double longitude { get; set; }
        public  double altitude { get; set; }
    }
}
