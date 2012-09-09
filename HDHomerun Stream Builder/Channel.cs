using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDHomerun_Stream_Builder
{
    public class Channel
    {
        public string Device { get; set; }
        public string Tuner { get; set; }
        public string Id { get; set; }
        public string Number { get; set; }
        public bool Encrypted { get; set; }
        public string Callsign { get; set; }
        public int VirtualNumberAsInt
        {
            get
            {
                int temp = 0;
                int.TryParse(this.VirtualNumber, out temp);
                return temp;
            }
            private set { }
        }
        public string ProxyProgram { get; set; }
        public string VirtualNumber { get; set; }
        public string Name { get; set; }
        public string StreamUrl
        {
            get
            {
                return "hdhomerun://" + Device + "-" + Tuner + "/tuner" + Tuner + "?channel=auto:" + Number + "&program=" + ProxyProgram;
            }
            private set { }
        }
        public bool Checked { get; set; }
        public string Filename
        {
            get
            {
                return VirtualNumber + " - " + Utils.MakeSafeFilename(Name, '_') + ".strm";
            }
            private set { }
        }

        public Channel(string num, string device, string tuner)
        {
            Number = num;
            Device = device;
            Tuner = tuner;
        }
    }
}
