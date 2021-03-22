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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OpenImageViewer
{
    public partial class Thumbnails : Form
    {


        public delegate void ShowImageDelegate(string name, int idx);
        public ShowImageDelegate ShowImage;

        public Thumbnails()
        {
            InitializeComponent();
        }

        public void Populate(ArrayList files)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            imageList1.Images.Clear();
            listView1.Items.Clear();
            int idx = 0;
            imageList1.ImageSize = new Size(160, 120);
            listView1.SuspendLayout();
            foreach (string fn in files)
            {
                Image img = GetThumbnail(fn);
                if (img != null)
                {
                    imageList1.Images.Add(img);
                    listView1.Items.Add(fn, idx++);
                }
                else
                    listView1.Items.Add(fn);
            }
            listView1.ResumeLayout();
            toolStripStatusLabel1.Text = "Count: "+idx;
            this.Cursor = Cursors.Arrow;
        }
        protected Int32 ScaleImage(Int32 imgWidth, Int32 imgHeight)
        {

            double imgW = (double)imgWidth;
            double imgH = (double)imgHeight;

            imgH = imgH * (160 / imgW);
            imgHeight = Convert.ToInt32(imgH);

            return imgHeight;

        }

        private Image GetThumbnail(string path)
        {
            Image img = null;
            FileStream fs = null;
            if (".CR2,.CRW".Contains(Path.GetExtension(path)))
            {
                try
                {
                    RCdll.Finish();
                    int width = 0, height = 0, tsize = 0;
                    if (RCdll.GetSize(path, ref width, ref height, ref tsize))
                    {
                        if (tsize > 0)
                        {
                            string fntmp = Path.GetTempFileName();
                            if (RCdll.SaveThumb(path, fntmp))
                            {
                                fs = new FileStream(fntmp, FileMode.Open, FileAccess.Read);
                                img = Image.FromStream(fs);
                                fs.Close();
                                File.Delete(fntmp);
                                Int32 ImgW = img.Width;
                                Int32 ImgH = img.Height;
                                Int32 imgHeight = ScaleImage(ImgW, ImgH);
                                try
                                {

                                    img = img.GetThumbnailImage(160, imgHeight, null, IntPtr.Zero);
                                }
                                catch {
                                    Image thumb = new Bitmap(160, imgHeight);
                                    using (Graphics graphics = Graphics.FromImage(thumb))
                                    {
                                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                                        graphics.DrawImage(img, 0, 0, 160, imgHeight);
                                    }

                                }
                            }
                        }
                    }
                }
                catch { };
            }
            else
            {
                System.Drawing.Imaging.PropertyItem p;
                try
                {
                    fs = File.OpenRead(path);
                    img = Image.FromStream(fs, false, false);
                    try
                    {
                        p = img.GetPropertyItem(0x501B);
                        img.Dispose();
                        MemoryStream ms = new MemoryStream(p.Value);
                        img = Image.FromStream(ms);
                        ms.Close();
                        ms.Dispose();
                    }
                    catch
                    {
                        try
                        {
                            Int32 ImgW = img.Width;
                            Int32 ImgH = img.Height;
                            Int32 imgHeight = ScaleImage(ImgW, ImgH);
                            img = img.GetThumbnailImage(160, imgHeight, null, IntPtr.Zero);
                        }
                        catch { img = null; }
                    }
                }
                catch
                {
                    return null;
                }
                fs.Close();
            }
            return img;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;
            if (ShowImage != null)
                ShowImage(listView1.SelectedItems[0].Text, listView1.SelectedIndices[0]);
        }

        private void Thumbnails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            listView1.Items.Clear();
            this.Hide();
        }

        
        private void listView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Hide();
            else
                if (e.KeyCode == Keys.Enter)
                    listView1_DoubleClick(null, null);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                toolStripStatusLabel2.Text = "Selected: none";
            else
                toolStripStatusLabel2.Text = "Selected: " + (listView1.SelectedIndices[0]+1);
        }
    }
}