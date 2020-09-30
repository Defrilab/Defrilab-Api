using System.IO;

namespace ReaiotBackend.Dtos
{
    public class BlobItemDto
    {
        public  Stream  TakenImage { get; set; }
        public  string  ProjectName { get; set; }
    }
}
