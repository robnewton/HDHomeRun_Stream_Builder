using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDHomerun_Stream_Builder
{
    public class Settings
    {
        public string HDHRPath { get; set; }
        public string MC2XMLPath { get; set; }
        public string TVGuidePath { get; set; }
        public string Device { get; set; }
        public string Tuner { get; set; }
        public string StrmFilePath { get; set; }
        public string PseudoTVSettingsPath { get; set; }
        public bool IgnoreAllEncrypted { get; set; }
        public bool IgnoreZeroProgram { get; set; }

        public Settings()
        {
        }

        public Settings(string hdhr, string mc2xml, string tvguide)
        {
            HDHRPath = hdhr;
            MC2XMLPath = mc2xml;
            TVGuidePath = tvguide;
        }
    }
}
