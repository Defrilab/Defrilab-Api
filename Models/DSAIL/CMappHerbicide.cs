namespace ReaiotBackend.Models.DSAIL
{
    public class CMappHerbicide : BaseModel
    {
        public int InitialQnt { get; set; }
        public int CurrentQnt { get; set; }
        public int TodayUsageQt { get; set; }
        public string EstimateDepletionDate { get; set; }
    }
}
