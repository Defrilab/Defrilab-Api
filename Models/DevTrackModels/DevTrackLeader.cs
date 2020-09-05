namespace ReaiotBackend.Models.DevTrackModels
{
    public class DevTrackLeader : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PopularName { get; set; }
        public string Position { get; set; }
        public string County { get; set; }
        public string FirstDateInOffice { get; set; }
        public string ProfilePhotoPath { get; set; }
    }
}
