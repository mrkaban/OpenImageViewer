/************************************************************************
OpenImageViewer - Image viewer with minimal user interface and advanced capabilities.
Copyright (C) 2008 - 2011  Lazar Laszlo

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

http://OpenImageViewer.sourceforge.net/
mailto:laszlolazar@yahoo.com
************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenImageViewer
{
    public partial class EnterComment : Form
    {
        public EnterComment()
        {
            InitializeComponent();
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.button3, "Filter only the selected area");
            toolTip1.SetToolTip(this.button4, "Save only the selected area");
            toolTip1.SetToolTip(this.button5, "Crop the image to the selected area");
            toolTip1.SetToolTip(this.button6, "Copy to clipboard only the selected area");
        }
        private string _comment;

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; textBox1.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _comment = textBox1.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _comment = null;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "filter";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "save";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "crop";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "copy";
        }

        private void EnterComment_Load(object sender, EventArgs e)
        {

        }
    }
}