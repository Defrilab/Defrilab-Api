namespace ReaiotBackend.Models
{
    public class Help : BaseModel
    {
        public string HelpName { get; set; }
        public string Description { get; set; }
        public string DateOfReporting { get; set; }
        public string ProblemLevel { get; set; }
        public  string  Project { get; set; }
    }
}
