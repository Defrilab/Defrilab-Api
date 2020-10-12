namespace ReaiotBackend.Models.DSAIL
{
    public class CMappSeedling : BaseModel
    {
        public string Species { get; set; }
        public int InitialQnt { get; set; }
        public int CurrentQnt { get; set; }
        public string PlantingDate { get; set; }
        public string EstimateWeedDate { get; set; }
        public string EstimateHarvestDate { get; set; }
    }
}
