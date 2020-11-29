using ReaiotBackend.Models.TtnTest;

namespace ReaiotBackend.Models
{
    public class metadata 
    {
        public  string time { get; set; }
        public  double frequency { get; set; }
        public  string modulation { get; set; }
        public  string data_rate { get; set; }
        public  int bit_rate { get; set; }
        public  string coding_rate { get; set; }
        public gateways gateways { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double altitude { get; set; }
    }

}
