/************************************************************************
OpenImageViewer - Image viewer with minimal user interface and advanced capabilities.
Copyright (C) КонтинентСвободы.рф

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

https://КонтинентСвободы.рф/
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
    public partial class Filters : Form
    {
        private bool _brchanged = false;
        private bool _gammachanged = false;
        private bool _contrastchanged = false;
        private bool _satchanged = false;
        private bool _binchanged = false;
        private AForge.Imaging.ImageStatistics istat;
        private AForge.Math.Histogram hist = null;

        public Filters()
        {
            InitializeComponent();
        }
        
        public Bitmap fimg;
        public PictureBox mainimg;
        public Image oldimg;
        public bool region = false;
        public Rectangle rreg;

        private void btApply_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Bitmap timg = null;
            try
            {
                oldimg = mainimg.Image;
                if (rbGray.Checked)
                {
                    AForge.Imaging.Filters.GrayscaleBT709 f = new AForge.Imaging.Filters.GrayscaleBT709();
                    timg = f.Apply(fimg);
                }

                if (rbMedian.Checked)
                {
                    AForge.Imaging.Filters.Median f = new AForge.Imaging.Filters.Median();
                    timg = f.Apply(fimg);
                }

                if (rbSepia.Checked)
                {
                    AForge.Imaging.Filters.Sepia f = new AForge.Imaging.Filters.Sepia();
                    timg = f.Apply(fimg);
                }

                if (rbSharp.Checked)
                {
                    AForge.Imaging.Filters.Sharpen f = new AForge.Imaging.Filters.Sharpen();
                    timg = f.Apply(fimg);
                }

                if (rbOil.Checked)
                {
                    AForge.Imaging.Filters.OilPainting f = new AForge.Imaging.Filters.OilPainting();
                    timg = f.Apply(fimg);
                }
                if (rbSmooth.Checked)
                {
                    AForge.Imaging.Filters.AdaptiveSmooth f = new AForge.Imaging.Filters.AdaptiveSmooth();
                    timg = f.Apply(fimg);
                }
                if (rbInvert.Checked)
                {
                    AForge.Imaging.Filters.Invert f = new AForge.Imaging.Filters.Invert();
                    timg = f.Apply(fimg);
                }
                if (rbPixelate.Checked)
                {
                    AForge.Imaging.Filters.Pixellate f = new AForge.Imaging.Filters.Pixellate();
                    timg = f.Apply(fimg);
                }
                if (rbJitter.Checked)
                {
                    AForge.Imaging.Filters.Jitter f = new AForge.Imaging.Filters.Jitter();
                    timg = f.Apply(fimg);
                }
                if (rbEdges.Checked)
                {
                    AForge.Imaging.Filters.IFilter f=null;
                    switch (cmbEdges.Text)
                    {
                        case "Convolution":
                            f = new AForge.Imaging.Filters.Edges();
                            break;
                        case "Homogenity":
                            f = new AForge.Imaging.Filters.HomogenityEdgeDetector();
                            break;
                        case "Difference":
                            f = new AForge.Imaging.Filters.DifferenceEdgeDetector();
                            break;
                        case "Sobel":
                            f = new AForge.Imaging.Filters.SobelEdgeDetector();
                            break;
                    }
                    if(f!=null)
                        timg = f.Apply(fimg);
                }
                if (rbBlur.Checked)
                {
                    AForge.Imaging.Filters.Blur f = new AForge.Imaging.Filters.Blur();
                    timg = f.Apply(fimg);
                }
                if (rbRotate.Checked)
                {
                    AForge.Imaging.Filters.RotateChannels f = new AForge.Imaging.Filters.RotateChannels();
                    timg = f.Apply(fimg);
                }

                if (_brchanged)
                {
                    AForge.Imaging.Filters.BrightnessCorrection f = new AForge.Imaging.Filters.BrightnessCorrection(Convert.ToDouble(tbBr.Text) );
                    timg = f.Apply(fimg);
                }
                if (_contrastchanged)
                {
                    AForge.Imaging.Filters.ContrastCorrection f = new AForge.Imaging.Filters.ContrastCorrection(Convert.ToDouble(tbContrast.Text));
                    timg = f.Apply(fimg);
                }
                if (_gammachanged)
                {
                    AForge.Imaging.Filters.GammaCorrection f = new AForge.Imaging.Filters.GammaCorrection(Convert.ToDouble(tbGamma.Text));
                    timg = f.Apply(fimg);
                }
                if (_satchanged)
                {
                    AForge.Imaging.Filters.SaturationCorrection f = new AForge.Imaging.Filters.SaturationCorrection(Convert.ToDouble(tbSat.Text));
                    timg = f.Apply(fimg);
                }
                if (_binchanged)
                {
                    AForge.Imaging.Filters.Threshold f = new AForge.Imaging.Filters.Threshold(Convert.ToByte(tbBin.Text));
                    timg = f.Apply(fimg);
                }

                if (region)
                {
                    Image ttimg = (Image)mainimg.Image.Clone();
                    using (Graphics g = Graphics.FromImage(ttimg))
                    {
                        g.DrawImage(timg, rreg);
                    }
                    mainimg.Image = ttimg;
                    mainimg.Refresh();
                }
                else
                {
                    if (timg != null)
                    {
                        mainimg.Image = timg;
                        fimg = timg;
                    }
                }

                if (timg != null)
                {
                    DrawHist(comboBox1.Text, timg);
                    btUndo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AForge imaging error: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Cursor = Cursors.Arrow;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (mainimg.Image != fimg && fimg !=null)
            {
                fimg.Dispose();
                fimg = null;
            }
            if (mainimg.Image != oldimg && oldimg != null)
            {
                oldimg.Dispose();
                oldimg = null;
            }
            this.Close();
        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            if (!region)
            {
                fimg = new Bitmap(oldimg);

                oldimg.Dispose();
                oldimg = null;

                mainimg.Image = fimg;
            }
            else
            {
                mainimg.Image = oldimg;
            }
            DrawHist(comboBox1.Text, fimg);
            _brchanged = false;
            _gammachanged = false;
            _contrastchanged = false;
            _satchanged = false;
            _binchanged = false;
            foreach (Control c in groupBox1.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton r = (RadioButton)c;
                    r.Checked = false;
                }
            }
                
            btUndo.Enabled = false;
        }

        private void ShowHist(string chn)
        {
            
            Color c = Color.Black;
            if (istat.IsGrayscale)
            {
                chn = "Gray";
                comboBox1.Text = "Gray";
            }
            else
                if(chn.Equals("Gray"))
            {
                chn = "Red";
                comboBox1.Text = "Red";
            }
            switch (chn)
            {
                case "Red":
                    hist = istat.Red;
                    c = Color.Red;
                    break;
                case "Green":
                    hist = istat.Green;
                    c = Color.Green;
                    break;
                case "Blue":
                    hist = istat.Blue;
                    c = Color.Blue;
                    break;
                case "Gray":
                    hist = istat.Gray;
                    c = Color.Gray;
                    break;
            }
            histogram1.Color = c;
            histogram1.Values = hist.Values;
            lblMean.Text = String.Format("{0:F2}", hist.Mean);
            lblStdDev.Text = String.Format("{0:F2}", hist.StdDev);
            lblMedian.Text = String.Format("{0:F2}", hist.Median);
            lblMin.Text = String.Format("{0:F2}", hist.Min);
            lblMax.Text = String.Format("{0:F2}", hist.Max);
        }
        private void DrawHist(string chn, Bitmap img)
        {
            try
            {
                istat = new AForge.Imaging.ImageStatistics(img);
                ShowHist(chn);
            }
            catch (Exception )
            {
            }
        }

        private void Filters_Load(object sender, EventArgs e)
        {
            DrawHist("Red",fimg);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowHist(comboBox1.Text);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            _brchanged = true;
            double d = Convert.ToDouble(trackBar1.Value) / 100;
            tbBr.Text = d.ToString();
        }


        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            _gammachanged= true;
            double d=Convert.ToDouble(trackBar2.Value)/100;
            tbGamma.Text = d.ToString();

        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            _contrastchanged = true;
            double d = Convert.ToDouble(trackBar3.Value) / 100;
            tbContrast.Text = d.ToString();
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            _satchanged = true;
            double d = Convert.ToDouble(trackBar4.Value) / 100;
            tbSat.Text = d.ToString();
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            _binchanged = true;
            tbBin.Text = trackBar5.Value.ToString();
        }

        private void histogram1_PositionChanged(object sender, IPLab.HistogramEventArgs e)
        {
            if (e.Position != -1)
            {

                lblLevel.Text = e.Position.ToString();
                lblCount.Text = hist.Values[e.Position].ToString();
                lblPerc.Text = ((float)hist.Values[e.Position] * 100 / istat.PixelsCount).ToString("F2");
            }
            else
            {
                lblLevel.Text = "";
                lblCount.Text = "";
                lblPerc.Text = "";
            }
        }

        private void histogram1_SelectionChanged(object sender, IPLab.HistogramEventArgs e)
        {
            int min = e.Min;
            int max = e.Max;
            int count = 0;

            lblLevel.Text = min.ToString() + "..." + max.ToString();

            // count pixels
            for (int i = min; i <= max; i++)
            {
                count += hist.Values[i];
            }
            lblCount.Text = count.ToString();
            lblPerc.Text = ((float)count * 100 / istat.PixelsCount).ToString("F2");
        }

        private void cmbEdges_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbEdges_MouseClick(object sender, MouseEventArgs e)
        {
            rbEdges.Checked = true;
        }

    }
}