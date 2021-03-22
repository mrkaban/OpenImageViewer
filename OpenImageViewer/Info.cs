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
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }
        private string fn;

        public string FileName
        {
            get { return fn; }
            set { fn = value; this.textBox1.Text = fn; }
        }
        private string width;

        public string Width
        {
            get { width = textBox2.Text; return width; }
            set { width = value; this.textBox2.Text = width; }
        }
        private string height;

        public string Height
        {
            get { height = textBox3.Text; return height; }
            set { height = value; this.textBox3.Text = height; }
        }
        private string frames;

        public string Frames
        {
            get { return frames; }
            set { frames = value; this.textBox4.Text = frames; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int w = Convert.ToInt32(textBox2.Text);
            int h = Convert.ToInt32(textBox3.Text);
            w = w / 2;
            h = h / 2;
            textBox2.Text = w.ToString();
            textBox3.Text = h.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int w = Convert.ToInt32(textBox2.Text);
            int h = Convert.ToInt32(textBox3.Text);
            w = w * 2;
            h = h * 2;
            textBox2.Text = w.ToString();
            textBox3.Text = h.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "800";
            textBox3.Text = "600";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "1024";
            textBox3.Text = "768";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "1280";
            textBox3.Text = "1024";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}