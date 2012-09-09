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
    public partial class SelectionRange : Form
    {
        public SelectionRange()
        {
            InitializeComponent();
        }

        public int Start
        {
            get{
                int temp = 0;
                int.TryParse(startRange.Text, out temp);
                return temp;
            }
            private set { }
        }

        public int End
        {
            get
            {
                int temp = 0;
                int.TryParse(endRange.Text, out temp);
                return temp;
            }
            private set { }
        }

        public bool ClearOtherChecked
        {
            get
            {
                return clearExisting_cb.Checked;
            }
            private set { }
        }
    }
}
