namespace ReaiotBackend.Models.DSAIL
{
    public class CMappFertilizer : BaseModel
    {
        public int InitialQnt { get; set; }
        public int CurrentQnt { get; set; }
        public int TodayUsageQt { get; set; }
        public string EstimateDepletionDate { get; set; }
    }
}
