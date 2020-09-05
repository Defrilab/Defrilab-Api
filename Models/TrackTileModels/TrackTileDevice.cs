using ReaiotBackend.Models.TrackTileModels;
using System;
using System.Collections.Generic;

namespace ReaiotBackend.Models.ReiotModels.TrackTileModels
{
    public class TrackTileDevice : BaseModel
    {
        public string gateway_id { get; set; }
        public DateTime date_modified { get; set; }
        public string owner { get; set; }
        public string name { get; set; }
        public List<TrackTileSensor> sensors { get; set; }
        public List<TrackTileActuator> actuators { get; set; }
        public DateTime date_created { get; set; }
    }
}
