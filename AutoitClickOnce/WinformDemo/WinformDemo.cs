using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformDemo
{
    public partial class WinformDemo : Form
    {
        public WinformDemo()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                IDataObject iData = Clipboard.GetDataObject();

                // Determines whether the data is in a format you can use.
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    // Yes it is, so display it in a text box.
                    lblClipBoard.Text = (String)iData.GetData(DataFormats.Text);
                }
            }
        }
    }
}
