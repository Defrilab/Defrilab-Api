namespace ReaiotBackend.Models.services
{
    public class Order : BaseModel
    {
        public  string  Email { get; set; }
        public  string  Username { get; set; }
        public  string  ServiceType { get; set; }
        public  string  ServiceLevel { get; set; }
        public  string  Description { get; set; }
    }
}
