namespace ReaiotBackend.Models.DSAIL
{
    public class CmappTask : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public  bool IsTaskRepeated { get; set; }
    }
}
