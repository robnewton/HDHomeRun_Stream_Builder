using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HDHomerun_Stream_Builder
{
    public class XMLTVChannel
    {
        public string Id { get; set; }
        public List<string> DisplayNames { get; set; }
        public string VirtualNumber
        {
            get
            {
                try
                {
                    return DisplayNames[1];
                }
                catch (Exception) { return ""; }
            }
            private set { }
        }
        public string Callsign
        {
            get
            {
                try
                {
                    return DisplayNames[2];
                }
                catch (Exception) { return ""; }
            }
            private set { }
        }
        public string Fullname
        {
            get
            {
                try
                {
                    if (DisplayNames.Count == 4)
                        return DisplayNames[2];
                    else
                        return DisplayNames[3];
                }
                catch (Exception) { return ""; }
            }
            private set { }
        }
        public string Network
        {
            get
            {
                try
                {
                    return DisplayNames[4];
                }
                catch (Exception) { return ""; }
            }
            private set { }
        }

        public XMLTVChannel() { }

        public XMLTVChannel(XElement element)
        {
            LoadFromXML(element);
        }

        public void LoadFromXML(XElement element)
        {
            Id = (string)element.Attribute("id");
            DisplayNames = new List<string>();
            foreach (XElement xe1 in element.Descendants())
            {
                switch (xe1.Name.ToString())
                {
                    case "display-name":
                        DisplayNames.Add((string)xe1);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
