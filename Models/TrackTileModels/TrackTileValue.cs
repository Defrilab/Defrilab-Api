using System;

namespace ReaiotBackend.Models.ReiotModels.TrackTileModels
{
    public class TrackTileValue : BaseModel
    {
        public DateTime date_received { get; set; }
        public int value { get; set; }
        public DateTime timestamp { get; set; }
    }
}
