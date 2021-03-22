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
using System.IO;

namespace OpenImageViewer
{
    public partial class Print : Form
    {

        public Image Image2Print = null;

        public int Count;

        private int _count;

        public int Frames = 0;

        public Print()
        {
            InitializeComponent();
            printDocument1.DefaultPageSettings.Margins.Left = 0;
            printDocument1.DefaultPageSettings.Margins.Right = 0;
            printDocument1.DefaultPageSettings.Margins.Top = 0;
            printDocument1.DefaultPageSettings.Margins.Bottom = 0;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Image2Print.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, _count);
            }
            catch (Exception)
            {
                return;
            }

            MemoryStream byteStream = new MemoryStream();
            Image2Print.Save(byteStream, System.Drawing.Imaging.ImageFormat.Bmp);
            Image pimg = Image.FromStream(byteStream);

            double rate = (double)pimg.Height / (double)pimg.Width;
            double scrate = (double)e.MarginBounds.Height / (double)e.MarginBounds.Width;

            double height = (double)e.MarginBounds.Height;

            Rectangle prec = e.MarginBounds;



            if (rbFZoom.Checked)
            {

                if (rate > scrate)
                {
                    height = (double)e.MarginBounds.Height;
                    double width = height / rate;
                    prec = new Rectangle(e.MarginBounds.X, e.MarginBounds.Y, (int)width, (int)height);
                }
                else
                {
                    prec = new Rectangle(e.MarginBounds.X, e.MarginBounds.Y, e.MarginBounds.Width, (int)((double)e.MarginBounds.Width * rate));
                }
                e.Graphics.DrawImage(pimg, prec);
            }else
            if (rb1.Checked)
            {
                e.Graphics.DrawImage(pimg, e.MarginBounds.X, e.MarginBounds.Y);
            }
            else
                e.Graphics.DrawImage(pimg, prec);

            if (checkBox1.Checked)
            {
                _count++;
                if (_count < Frames)
                {
                    e.HasMorePages = true;   
                }
                else
                    _count = 0;
            }
        }

        private void bPreview_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDocument1;

            if (checkBox1.Checked)
            {
                _count = 0;
            }
            else
            {
                _count = Count;
            }

            ppd.ShowDialog();
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument1;
            DialogResult result = pd.ShowDialog();
            if (checkBox1.Checked)
            {
                _count = 0;
            }
            else
            {
                _count = Count;
            }
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }

        }

        private void bPage_Click(object sender, EventArgs e)
        {
            PageSetupDialog psd = new PageSetupDialog();
            psd.Document = printDocument1;
            psd.ShowDialog();
        }
    }
}