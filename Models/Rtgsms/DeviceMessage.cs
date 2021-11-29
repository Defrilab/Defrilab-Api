using System;

namespace ReaiotBackend.Models.Rtgsms
{
    public class DeviceMessage : BaseModel
    {
        public  UInt16  Lat { get; set; }
        public  UInt16  Long { get; set; }
        public  UInt16 Geophone_analog_value { get; set; }
        public  UInt16  LDR { get; set; }
        public  UInt16 X_acc { get; set; }
        public UInt16 Y_acc { get; set; }
        public UInt16 Z_acc { get; set; }
        public  short  Temp { get; set; }
        public  UInt16  Hum { get; set; }
        public  UInt16  Flags { get; set; }

        //device specific infor
        public  string Device { get; set; }
        public  string  Data { get; set; }

    }
}
