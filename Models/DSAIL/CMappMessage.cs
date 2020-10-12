using System;

namespace ReaiotBackend.Models.DSAIL
{
    public class CmappMessage : BaseModel
    {
        public  string AttachementUrl { get; set; }
        public  bool IsIncoming { get; set; }
        public  DateTime MessageDateTime { get; set; }
        public  string Text { get; set; }
        public  string MessageTimeDisplay { get; set; }
        public  bool HasAttachement { get; set; }
        public  string SenderImageUri { get; set; }
    }
}
