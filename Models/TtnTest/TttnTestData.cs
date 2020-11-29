using ReaiotBackend.Models.TtnTest;

namespace ReaiotBackend.Models
{
    public class TttnTestData
    {
        public  string app_id { get; set; }
        public  string dev_id { get; set; }
        public  string hardware_serial { get; set; }
        public int port { get; set; }
        public int counter { get; set; }
        public  bool is_retry { get; set; }
        public  bool confirmed { get; set; }
        public  string payload_raw { get; set; }
        public payload_fields payload_fields { get; set; }
        public  metadata  metadata { get; set; }
        public  string downlink_url { get; set; }
    }
}
