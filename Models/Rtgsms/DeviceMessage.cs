using System;

namespace ReaiotBackend.Models.Rtgsms
{
    public class DeviceMessage : BaseModel
    {
        public  UInt16  Lat { get; set; }
        public  UInt16  Long { get; set; }
        public  int GeophoneAnalogValue { get; set; }
        public  UInt16  LDR { get; set; }
        public  UInt16  ACC_X { get; set; }
        public UInt16 ACC_Y { get; set; }
        public UInt16 ACC_Z { get; set; }
        public  short  Temp { get; set; }
        public  UInt16  Hum { get; set; }
        public  UInt16  Flags { get; set; }

        //device specific infor
        public  string Device { get; set; }
        public  string  Data { get; set; }

    }
}
