namespace ReaiotBackend.Models.Services
{
    public class MeetBooking : BaseModel
    {
        public  string  Email { get; set; }
        public  string  Username { get; set; }
        public  string  Date { get; set; }
        public  string  Time { get; set; }
        public  string  Description { get; set; }
    }
}
