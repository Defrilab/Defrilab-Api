using System.Collections.Generic;

namespace ReaiotBackend.Models.DevTrackModels
{
    public class DevTrackProject : BaseModel
    {
        public string Leader { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TimeSpan { get; set; }
        public string Sponsor { get; set; }
        public decimal Cost { get; set; }
        public string ProjectImage { get; set;}
    }
}
