using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HDHomerun_Stream_Builder
{
    public partial class AddChannelDlg : Form
    {
        public AddChannelDlg(string number="", string virtualNumber="", string proxy="", string name="", string callsign="")
        {
            InitializeComponent();
            this.number.Text = number;
            this.virtualNumber.Text = virtualNumber;
            this.proxy.Text = proxy;
            this.name.Text = name;
            this.callsign.Text = callsign;
        }
        
        public string Number
        {
            get
            {
                return number.Text;
            }
            private set { }
        }

        public string VirtualNumber
        {
            get
            {
                return virtualNumber.Text;
            }
            private set { }
        }

        public string Proxy
        {
            get
            {
                return proxy.Text;
            }
            private set { }
        }

        public string Name
        {
            get
            {
                return name.Text;
            }
            private set { }
        }

        public string Callsign
        {
            get
            {
                return callsign.Text;
            }
            private set { }
        }
    }
}
