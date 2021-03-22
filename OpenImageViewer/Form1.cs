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
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Net;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OpenImageViewer
{

    public partial class Form1 : Form
    {
        //Thread updt;
        private int ZOOM = 20;
        private int SCROLL = 30;
        private const double PROCENT = 0.90;
        private const double MAXPROCENT = 0.95;

        private ArrayList _files;
        private ArrayList _comments;

        private int _position = -1;
        private bool _opened = false;
        private string _filename;
        private int _mouseX;
        private int _mouseY;
        private int _mousemoveX;
        private int _mousemoveY;
        private int _mousepanX;
        private int _mousepanY;
        private bool _drawbox = false;
        private Rectangle _oldrect;
        private Rectangle _rect;
        private bool _nocomment = false;
        private bool _fullscreen = false;
        private int _oldzoomW;
        private int _oldzoomH;
        private int _oldzoomX;
        private int _oldzoomY;
        private int _panX;
        private int _panY;
        private bool _zoomed = false;
        private bool _fadet = true;
        private int _frame = 0;
        private bool _mousemove = false;
        private bool _mousepan = false;
        private bool _noc = false;
        private bool _nofn = false;
        private bool _oldfadet = false;
        private bool _canmove = false;
        private bool _fullraw = true;

        private Font _font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        private double _fade = 0.10;

        private Byte _rotate = 0;

        private Thumbnails _thumbs = null;
        //private Bitmap screenBitmap;


        //public Bitmap ConvertToGrayscale(Bitmap source)
        //{

        //    Bitmap bm = new Bitmap(source.Width, source.Height);


        //    //AForge.Imaging.Filters.BrightnessCorrection f = new AForge.Imaging.Filters.BrightnessCorrection(-0.5);
        //    AForge.Imaging.Filters.GrayscaleBT709 f1 = new AForge.Imaging.Filters.GrayscaleBT709();
        //    bm = f1.Apply(source);
        //    AForge.Imaging.Filters.BrightnessCorrection f2 = new AForge.Imaging.Filters.BrightnessCorrection(-0.5);

        //    bm = f2.Apply(bm);

        //    return bm;

        //}

        public Form1(string[] args)
        {
            InitializeComponent();


            this.SetStyle(

              ControlStyles.AllPaintingInWmPaint |

              ControlStyles.UserPaint |

              ControlStyles.DoubleBuffer, true);


            Application.DoEvents();

            LoadSettings();

            if (args.Length > 0)
            {
                _filename = Path.GetFullPath(args[0]);
                POpen(true);
            }
            else
            {
                if (!GetImageClipBoard(false))
                {
                    _filename = Directory.GetCurrentDirectory();
                    POpen(true);
                }
            }
        }

        private void ZoomAll()
        {

            if (_zoomed)
            {
                pictureBox1.Bounds = new Rectangle(_oldzoomX, _oldzoomY, _oldzoomW, _oldzoomH);
            }
            else
            {
                _oldzoomH = this.pictureBox1.Height;
                _oldzoomW = this.pictureBox1.Width;
                _oldzoomX = this.pictureBox1.Location.X;
                _oldzoomY = this.pictureBox1.Location.Y;
                this.pictureBox1.Width = this.pictureBox1.Image.Width;
                this.pictureBox1.Height = this.pictureBox1.Image.Height;
                int nx, ny;
                if (this.pictureBox1.Width < this.Width)
                    nx = (this.Width - this.pictureBox1.Width) / 2;
                else
                    nx = 0;
                if (this.pictureBox1.Height < this.Height)
                    ny = (this.Height - this.pictureBox1.Height) / 2;
                else
                    ny = 0;
                this.pictureBox1.Location = new Point(nx, ny);
            }
            _zoomed = !_zoomed;
            LoadComments();
            DrawComments();
        }

        private void ScaleWindow(bool fullscreen)
        {
            double rate = (double)pictureBox1.Image.Height / (double)pictureBox1.Image.Width;
            Rectangle screen = Screen.GetBounds(this);
            double height = (double)screen.Height * PROCENT;
            double scrate = (double)screen.Height / (double)screen.Width;

            this.label1.Visible = false;

            

            if (fullscreen)
            {
                _canmove = false;
                this.TopMost = true;

                this.Width = screen.Width;
                this.Height = screen.Height;

                if (_zoomed)
                {
                    this.pictureBox1.Width = this.pictureBox1.Image.Width;
                    this.pictureBox1.Height = this.pictureBox1.Image.Height;
                }
                else
                if (pictureBox1.Image.Height > screen.Height && pictureBox1.Image.Width <= screen.Width)
                {
                    height = (double)screen.Height;
                    this.pictureBox1.Height = (int)height;
                    double width = height / rate;
                    this.pictureBox1.Width = (int)width;
                }
                else
                    if (pictureBox1.Image.Height < screen.Height && pictureBox1.Image.Width > screen.Width)
                    {
                        this.pictureBox1.Width = screen.Width;
                        this.pictureBox1.Height = (int)((double)this.Width * rate);
                    }
                    else
                        if (rate > scrate)
                        {
                            height = (double)screen.Height;
                            this.pictureBox1.Height = (int)height;
                            double width = height / rate;
                            this.pictureBox1.Width = (int)width;
                        }
                        else
                        {
                            this.pictureBox1.Width = screen.Width;
                            this.pictureBox1.Height = (int)((double)this.Width * rate);
                        }
                
                int nx,ny;
                if (this.pictureBox1.Width < this.Width)
                    nx = (this.Width - this.pictureBox1.Width) / 2;
                else
                    nx = 0;
                if (this.pictureBox1.Height < this.Height)
                    ny = (this.Height- this.pictureBox1.Height) / 2;
                else
                    ny = 0;
                this.pictureBox1.Location = new Point(nx, ny);
            }
            else
            {
                this.TopMost = false;
                _zoomed = false;
                _canmove = true;
                if ((double)pictureBox1.Image.Height > height)
                {
                    this.Height = (int)height;
                    double width = height / rate;
                    this.Width = (int)width;
                }
                else
                if (pictureBox1.Image.Height < screen.Height - 50)
                {
                    if (pictureBox1.Image.Width > screen.Width)
                    {
                        this.Width = screen.Width;
                        double h = (double)this.Width * rate;
                        this.Height = (int)h;
                    }
                    else
                    {
                        this.Height = pictureBox1.Image.Height;
                        double width = (double)this.Height / rate;
                        this.Width = (int)width;
                    }
                }
                else
                if (this.Height > pictureBox1.Image.Height)
                {
                    this.Height = pictureBox1.Image.Height;
                    double width = (double)this.Height * rate;
                    this.Width = (int)width;
                }
                pictureBox1.Bounds = new Rectangle(0, 0, this.Width, this.Height);
            }
            CheckFilename();
            //this.pictureBox1.Refresh();
            this.CenterToScreen();
        }

        private void SaveRect(Rectangle r, string cmt)
        {
            if (cmt.Equals("save") || cmt.Equals("filter") || cmt.Equals("crop") || cmt.Equals("copy"))
                return;
            BinaryWriter w = new BinaryWriter(File.Open((string)_files[_position] + ".cmt", FileMode.Append));
            w.Write(r.X);
            w.Write(r.Y);
            w.Write(r.Width);
            w.Write(r.Height);
            w.Write((Byte)_rotate);
            if (cmt == null)
                w.Write((string)"--");
            else
            {
                if(cmt.Length == 0)
                    w.Write((string)"--");
                else
                    w.Write(cmt);
            }
            w.Close();
        }

        private void SaveComments()
        {
            BinaryWriter w = new BinaryWriter(File.Open((string)_files[_position] + ".cmt", FileMode.Create));
            foreach (CComment c in _comments)
            {
                if (c.Comment.Equals("save") || c.Comment.Equals("filter") || c.Comment.Equals("crop") || c.Equals("copy"))
                    continue;
                w.Write(c.CRectangle.X);
                w.Write(c.CRectangle.Y);
                w.Write(c.CRectangle.Width);
                w.Write(c.CRectangle.Height);
                w.Write((Byte)c.Rotate);
                if (c.Comment == null)
                    w.Write((string)"--");
                else
                {
                    if (c.Comment.Length == 0)
                        w.Write((string)"--");
                    else
                        w.Write(c.Comment);
                }
            }
            w.Close();
        }

        private bool LoadComments()
        {
            BinaryReader w = null;
            bool _noc = true;
            _comments = new ArrayList();
            try
            {
                w = new BinaryReader(File.Open((string)_files[_position] + ".cmt", FileMode.Open));
                while (true)
                {
                    Rectangle rr = new Rectangle();
                    rr.X = w.ReadInt32();
                    rr.Y = w.ReadInt32();
                    rr.Width = w.ReadInt32();
                    rr.Height = w.ReadInt32();
                    byte rot = w.ReadByte();
                    string str = w.ReadString();
                    _comments.Add(new CComment(rr,str,rot));
                    if (w.BaseStream.Position == w.BaseStream.Length)
                        break;
                }
                _noc = false;
                w.Close();
            }
            catch (Exception ex)
            {
                if (_comments.Count != 0)
                    _noc = false;
                if(w!=null)
                    w.Close();
            }
            return _noc;
        }

        private void FindFiles(string ext,DirectoryInfo di)
        {
            FileInfo[] rgFiles = di.GetFiles(ext);
            foreach (FileInfo fi in rgFiles)
            {
                if (fi.Directory.ToString().EndsWith("\\"))
                    _files.Add(fi.Directory + fi.Name);
                else
                    _files.Add(fi.Directory + "\\" + fi.Name);
            }

        }

        private int OpenFile(string fn)
        {
            string dir;
            string[] exts = new string[] { "*.jpg", "*.gif", "*.bmp", "*.tif", "*.png", "*.jpeg", "*.ppm","*.cr2","*.crw" };
            try
            {
                if (Path.GetExtension(fn).Length == 0)
                {
                    if (!fn.EndsWith("\\"))
                        fn += "\\";
                }
                dir = Path.GetDirectoryName(fn);
                if (dir == null)
                    dir = fn;
                else
                if (dir.Length == 0)
                {
                    fn = Directory.GetCurrentDirectory() + "\\" + fn;
                }
                DirectoryInfo di = new DirectoryInfo(dir);
                _files = new ArrayList();

                for(int i = 0; i < exts.Length; i++)
                {
                    FindFiles(exts[i], di);
                }
                _files.Sort();

                if (Path.GetFileName(fn).Length == 0)
                {
                    return 0;
                }
                else
                {
                    int pos =0;
                    foreach (string str in _files)
                    {
                        if (str.Equals(fn))
                            break;
                        pos++;
                    }
                    //int pos = _files.BinarySearch((string)fn);
                    return pos;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private void EditComment(object o)
        {
            Control p = (Control)o;
            double rate = (double)this.pictureBox1.Width / (double)pictureBox1.Image.Width;

            foreach (Control c in this.pictureBox1.Controls)
            {
                if (Math.Abs(c.Bounds.X - (p.Bounds.X + 3))<5 && Math.Abs(c.Bounds.Y - (p.Bounds.Y + 3))<5)
                {
                    EnterComment ec = new EnterComment();
                    ec.Comment = c.Text;
                    ec.ShowDialog();
                    if (ec.Comment == null)
                        break;
                    c.Text = ec.Comment;
                    foreach (CComment com in _comments)
                    {
                        double x = (double)(com.CRectangle.X);
                        x=x * rate;
                        double y = (double)com.CRectangle.Y;
                        y=y*rate;
                        if (Math.Abs(Convert.ToInt32(x) - p.Bounds.X) < 5 && Math.Abs(Convert.ToInt32(y) - p.Bounds.Y) < 5) 
                        //com.CRectangle.Width == c.Bounds.Width && com.CRectangle.Height == c.Bounds.Height)
                        {
                            com.Comment = ec.Comment;
                        }
                    }
                    break;
                }
            }
            SaveComments();
        }

        private void DrawComments()
        {
            this.pictureBox1.Controls.Clear();
            if (_nocomment || _frame > 0)
                return;
            double rate = (double)this.pictureBox1.Width / (double)pictureBox1.Image.Width;
            foreach (CComment cc in _comments)
            {
                if (_rotate == cc.Rotate)
                {
                    string cmt = (string)cc.Comment;
                    if (!cmt.Equals("--"))
                    {
                        double x = (double)cc.CRectangle.X * rate;
                        double y = (double)cc.CRectangle.Y * rate;
                        double w = (double)cc.CRectangle.Width * rate;
                        double h = (double)cc.CRectangle.Height * rate;

                        Label lbl = new Label();
                        lbl.Text = cmt;
                        lbl.Location = new Point((int)x+3, (int)y+3);
                        lbl.AutoSize = true;
                        lbl.BackColor = System.Drawing.Color.White;
                        lbl.ForeColor = System.Drawing.Color.DarkBlue;
                        lbl.Name = "lbl" + x.ToString()+ y.ToString() ;
                        lbl.Font = _font;


                        Panel pnl = new Panel();
                        if (w < 10 || h < 10)
                        {
                            pnl.Location = new Point((int)x, (int)y);
                            pnl.Size = lbl.Size;
                            pnl.BorderStyle = BorderStyle.None;
                        }
                        else
                        {
                            pnl.Bounds = new Rectangle((int)x, (int)y, (int)w, (int)h);
                            pnl.BorderStyle = BorderStyle.Fixed3D;
                        }
                        pnl.BackColor = Color.Transparent;

                        pnl.Click += new EventHandler(pnl_Click);
                        lbl.MouseClick += new MouseEventHandler(lbl_MouseClick);

                        this.pictureBox1.Controls.Add(lbl);
                        this.pictureBox1.Controls.Add(pnl);

                    }
                }
            }
            this.Refresh();
        }

        void pnl_Click(object sender, EventArgs e)
        {
            EditComment(sender);
        }

        private void RestoreRotate(byte rot)
        {
            if (rot == 1)
                this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            else
                if (rot == 2)
                    this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                else
                    if (rot == 3)
                        this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        private void BackRotate(byte rot)
        {
            if (_rotate == 1)
                this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            else
                if (_rotate == 2)
                    this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                else
                    if (_rotate == 3)
                        this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

        private Image CreateImage(string fn)
        {
            Image ret = null;
            string ext = Path.GetExtension(fn);
            switch (ext)
            {
                case ".CR2":
                    RCdll.Finish();
                    int width=0, height=0, tsize=0;
                    if (RCdll.GetSize(fn, ref width, ref height, ref tsize))
                    {
                        if (_fullraw)
                        {
                            Bitmap bmp = new Bitmap(width, height);
                            Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
                            BitmapData bmpData = bmp.LockBits(r, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                            RCdll.LoadRaw(fn, 1, 0, bmpData.Scan0, bmpData.Stride);
                            //bmpData.Scan0 = imgptr;
                            bmp.UnlockBits(bmpData);
                            ret = bmp;
                        }
                        else
                        {
                            if (tsize > 0)
                            {
                                string fntmp = Path.GetTempFileName();
                                if (RCdll.SaveThumb(fn, fntmp))
                                {
                                    FileStream fs = new FileStream(fntmp, FileMode.Open, FileAccess.Read);
                                    ret = Image.FromStream(fs);
                                    fs.Close();
                                    File.Delete(fntmp);
                                }
                                //byte[] data = new byte[tsize + 1024];
                                //GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
                                //IntPtr ptr = h.AddrOfPinnedObject();
                                //RCdll.LoadThumb(fn, ptr);

                                //MemoryStream ms = new MemoryStream(data);
                                //ret = Image.FromStream(ms);
                                //h.Free();
                                //ms.Close();
                                //ms.Dispose();
                            }
                        }
                    }
                    break;
                default:
                    ret = Image.FromFile(fn);
                    break;
            }

            

            return ret;
        }

        private void POpen(bool reload)
        {
            _noc = false;

            this.Cursor = Cursors.WaitCursor;
            label1.Visible = false;

            if(_fadet)
                this.Opacity = 0.0;

            try
            {
                if(reload)
                    _position = OpenFile(_filename);

                if (_position >= 0)
                {
                    _noc = LoadComments();

                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    pictureBox1.Controls.Clear();
                    pictureBox1.Image = CreateImage((string)_files[_position]);//Image.FromFile((string)_files[_position]);

                    Bitmap bmp = (Bitmap)pictureBox1.Image.Clone();

                    string exifor = "";

                    try
                    {
                        EXIF.EXIFextractor er = new OpenImageViewer.EXIF.EXIFextractor(ref bmp, "\n");
                        if (er["Orientation"] != null)
                            exifor = er["Orientation"].ToString();
                        er = null;
                    }
                    catch { };

                    try
                    {
                        if (pictureBox1.Image.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page) > 1)
                            MessageBox.Show("Мульти-фрейм картинка!\n\rНажмите N для просмотра следующего фрейма!", "Мульти-фрейм", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                    }
                    _frame = 0;
                    
                    _rotate = 0;

                    bmp.Dispose();
                    bmp = null;

                    if (!_noc)
                    {
                        CComment c = (CComment)(_comments[_comments.Count - 1]);
                        RestoreRotate(c.Rotate);
                        _rotate = c.Rotate;
                    }
                    else
                    {
                        if(exifor.Length>0 && exifor!="0")
                        {
                            switch(exifor)
                            {
                                case "6":
                                    _rotate = 1;
                                    break;
                                case "8":
                                    _rotate = 3;
                                    break;
                                default:
                                    _rotate = 0;
                                    break;
                            }
                            RestoreRotate(_rotate);
                        }
                    }

                    ScaleWindow(_fullscreen);

                    label1.Text = (string)_files[_position];
                    this.Text = "OpenImageViewer " + label1.Text;
                    if (_noc)
                        label1.Text += " --- Нет комментариев !!!";
                    else
                    if (_nocomment)
                        label1.Text += " --- Комментарии скрыты !!!";

                    CheckFilename();

                    if(!_noc)
                        DrawComments();

                    _opened = true;
                    //_zoomed = false;
                    if(_fadet)
                        this.timer1.Enabled = true;
                }
            }
            catch (Exception)
            {
                _opened = false;
            }
            this.Cursor = Cursors.Arrow;
        }

        private void CheckFilename()
        {
            int w = this.label1.Bounds.X + this.label1.Bounds.Width;
            if (_nofn)
                this.label1.Visible = false;
            else
                if (w > this.Width)
                    this.label1.Visible = false;
                else
                    this.label1.Visible = true;
        }

        private void Exit()
        {
            if (_opened)
            {
                if (_fadet)
                {
                    _fade = -0.1;
                    this.pictureBox1.Controls.Clear();
                    this.timer1.Enabled = true;
                    if(_files != null)
                        _files.Clear();
                    SaveSettings();
                }
                else
                {
                    SaveSettings();
                    this.Close();
                }

            }
            else
            {
                this.Close();
                SaveSettings();
            }
}

        private void NextPicture()
        {
            if (_opened && _files!=null)
            {
                this.timer1.Enabled = false;
                _position += 1;
                if (_position > (_files.Count - 1))
                    _position = 0;
                POpen(false);
            }
        }
        private void PrevPicture()
        {
            if (_opened && _files != null)
            {
                this.timer1.Enabled = false;
                _position -= 1;
                if (_position < 0)
                    _position = _files.Count - 1;
                POpen(false);
            }
        }
        private void ZoomIn()
        {
            this.pictureBox1.Controls.Clear();
            this.timer2.Enabled = false;
            //this.pictureBox1.Refresh();

            double zoomX = (double)this.Width / (double)this.Height * (double)ZOOM;

            Rectangle screen = Screen.GetBounds(this);
            double height = (double)screen.Height * MAXPROCENT;


            if ((this.Size.Height + ZOOM > (int)height) )
            {
                if ((this.Size.Width + (int)zoomX) < screen.Width)
                {
                    zoomX = (double)this.pictureBox1.Width / (double)this.pictureBox1.Height * (double)ZOOM;
                    this.pictureBox1.Bounds = new Rectangle(this.pictureBox1.Location.X , this.pictureBox1.Location.Y - ZOOM, this.pictureBox1.Size.Width , this.pictureBox1.Size.Height + ZOOM * 2);
                    this.Bounds = new Rectangle(this.Location.X - (int)zoomX, this.Location.Y, this.Size.Width + (int)zoomX * 2, this.Size.Height);
                }
                else
                {
                    this.pictureBox1.Bounds = new Rectangle(this.pictureBox1.Location.X - (int)zoomX, this.pictureBox1.Location.Y - ZOOM, this.pictureBox1.Size.Width + (int)zoomX * 2, this.pictureBox1.Size.Height + ZOOM * 2);
                }
            }else
            if(this.Size.Width + (int)zoomX > screen.Width)
            {
                this.Bounds = new Rectangle(this.Location.X, this.Location.Y - ZOOM, this.Size.Width, this.Size.Height + ZOOM *2);
                this.pictureBox1.Bounds = new Rectangle(this.pictureBox1.Location.X - (int)zoomX, this.pictureBox1.Location.Y - ZOOM, this.pictureBox1.Size.Width + (int)zoomX * 2, this.pictureBox1.Size.Height + ZOOM * 2);
            }
            else
            {
                this.Bounds = new Rectangle(this.Location.X - (int)zoomX, this.Location.Y - ZOOM, this.Size.Width + (int)zoomX * 2, this.Size.Height + ZOOM * 2);
            }
            this.timer2.Enabled = true;
        }
        private void ZoomOut()
        {
            this.pictureBox1.Controls.Clear();
            this.timer2.Enabled = false;

            Rectangle screen = Screen.GetBounds(this);
            double height = (double)screen.Height * MAXPROCENT;
            double zoomX = (double)this.Width / (double)this.Height * (double)ZOOM;

            if ((this.Width - (int)zoomX) < 150)
                return;

            if ((this.Height - ZOOM) < 150)
                return;

            if (_fullscreen)
            {
                this.pictureBox1.Bounds = new Rectangle(this.pictureBox1.Location.X + (int)zoomX, this.pictureBox1.Location.Y + ZOOM, this.pictureBox1.Size.Width - (int)zoomX * 2, this.pictureBox1.Size.Height - ZOOM * 2);
                int nx, ny;
                if (this.pictureBox1.Width < this.Width)
                    nx = (this.Width - this.pictureBox1.Width) / 2;
                else
                    nx = 0;
                if (this.pictureBox1.Height < this.Height)
                    ny = (this.Height - this.pictureBox1.Height) / 2;
                else
                    ny = 0;
                this.pictureBox1.Location = new Point(nx, ny);
            }
            else
            if (this.pictureBox1.Size.Width > this.Size.Width )
            {
                this.pictureBox1.Bounds = new Rectangle(this.pictureBox1.Location.X + (int)zoomX, this.pictureBox1.Location.Y + ZOOM, this.pictureBox1.Size.Width - (int)zoomX * 2, this.pictureBox1.Size.Height - ZOOM * 2);
            }else
            if(this.pictureBox1.Size.Height > this.Size.Height)
            {
                zoomX = (double)this.pictureBox1.Width / (double)this.pictureBox1.Height * (double)ZOOM;
                this.pictureBox1.Bounds = new Rectangle(this.pictureBox1.Location.X, this.pictureBox1.Location.Y + ZOOM, this.pictureBox1.Size.Width, this.pictureBox1.Size.Height - ZOOM * 2);
                this.Bounds = new Rectangle(this.Location.X + (int)zoomX, this.Location.Y, this.Size.Width - (int)zoomX * 2, this.Size.Height);
            }
            else
            {
                this.Bounds = new Rectangle(this.Location.X + (int)zoomX, this.Location.Y + ZOOM, this.Size.Width - (int)zoomX * 2, this.Size.Height - ZOOM * 2);
                pictureBox1.Bounds = new Rectangle(0, 0, this.Width, this.Height);
            }
            this.timer2.Enabled = true;
        }


        private void Rotate90()
        {
            _zoomed = false;
            this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            //_fullscreen = false;
            ScaleWindow(_fullscreen);
            _rotate++;
            if (_rotate > 3)
                _rotate = 0;

            DrawComments();
        }
        private void RotateLeft()
        {
            _zoomed = false;
            this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            //_fullscreen = false;
            ScaleWindow(_fullscreen);
            _rotate--;
            if (_rotate == 0xff)
                _rotate = 3;

            DrawComments();
        }
        private void MovePicture(byte dir)
        {
            if (this.pictureBox1.Size.Width <= this.Size.Width && this.pictureBox1.Size.Height<=this.Size.Height)
            {
                switch (dir)
                {
                    case 0:
                        ZoomIn();
                        break;
                    case 1:
                        NextPicture();
                        break;
                    case 2:
                        ZoomOut();
                        break;
                    case 3:
                        PrevPicture();
                        break;
                }
                return;
            }
            switch (dir)
            {
                case 0:
                    if (this.pictureBox1.Location.Y + SCROLL <= 0)
                        this.pictureBox1.Location = new Point(this.pictureBox1.Location.X, this.pictureBox1.Location.Y + SCROLL);
                    break;
                case 1:
                    this.pictureBox1.Location = new Point(this.pictureBox1.Location.X - SCROLL, this.pictureBox1.Location.Y);
                    break;
                case 2:
                    this.pictureBox1.Location = new Point(this.pictureBox1.Location.X, this.pictureBox1.Location.Y - SCROLL);
                    break;
                case 3:
                    if (this.pictureBox1.Location.X + SCROLL <= 0)
                        this.pictureBox1.Location = new Point(this.pictureBox1.Location.X + SCROLL, this.pictureBox1.Location.Y);
                    break;
            }
        }

        private void ToggleComments()
        {
            if (_files == null)
                return;
            _nocomment = !_nocomment;
            if (_nocomment)
            {
                this.pictureBox1.Controls.Clear();
                label1.Text = (string)_files[_position];
                if (_noc)
                    label1.Text += " --- Нет комментариев !!!";
                else
                    label1.Text += " --- Комментарии скрыты !!!";
            }
            else
            {
                DrawComments();
                label1.Text = (string)_files[_position];
                if(_noc)
                    label1.Text += " --- Нет комментариев !!!";
            }
        }

        private void NextFrame()
        {
            int count;
            try
            {
                count = pictureBox1.Image.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
            }
            catch (Exception)
            {
                count = 1;
            }
            _frame++;

            if (_frame >= count)
                _frame = 0;
            try
            {
                pictureBox1.Image.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, _frame);
                this.pictureBox1.Refresh();
                ScaleWindow(_fullscreen);
                DrawComments();
            }
            catch (Exception)
            {
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            //Debug.WriteLine(keyData & Keys.Modifiers);
            if ((keyData & Keys.Modifiers) == Keys.Control && (keyData & (Keys.KeyCode)) == Keys.V)
                GetImageClipBoard(true);
            if ((keyData & Keys.Modifiers) == Keys.Control && (keyData & (Keys.KeyCode)) == Keys.C)
                CopyImageClipBoard();
            switch (keyData)
            {
                case Keys.Back:
                case Keys.PageDown:
                    PrevPicture();
                    break;
                case Keys.Space:
                case Keys.PageUp:
                    NextPicture();
                    break;
                case Keys.Escape:
                    Exit();
                    break;
                case Keys.Add:
                    ZoomIn();
                    break;
                case Keys.Subtract:
                    ZoomOut();
                    break;
                case Keys.R:
                    Rotate90();
                    break;
                case Keys.L:
                    RotateLeft();
                    break;
                case Keys.F1:
                    ShowHelp();
                    break;
                case Keys.F5:
                    Reload();
                    break;
                case Keys.Left:
                    MovePicture(3);
                    break;
                case Keys.Right:
                    MovePicture(1);
                    break;
                case Keys.Up:
                    MovePicture(0);
                    break;
                case Keys.Down:
                    MovePicture(2);
                    break;
                case Keys.F:
                    Fullscreen();
                    break;
                case Keys.C:
                    ToggleComments();
                    break;
                case Keys.P:
                    PrintImage();
                    break;
                case Keys.Z:
                    ZoomAll();
                    break;
                case Keys.T:
                    _fadet = !_fadet;
                    break;
                case Keys.N:
                    NextFrame();
                    break;
                case Keys.I:
                    Infos();
                    break;
                case Keys.A:
                    Filter();
                    break;
                case Keys.S:
                    Save();
                    break;
                case Keys.E:
                    ShowExifInfo();
                    break;
                case Keys.H:
                    _nofn = !_nofn;
                    CheckFilename();
                    break;
                case Keys.O:
                    Crop();
                    break;
                case Keys.M:
                    this.TopMost = !this.TopMost;
                    break;
                case Keys.D:
                    lblInfo.Visible = !lblInfo.Visible;
                    break;
                case Keys.Delete:
                    Delete();
                    break;
                case Keys.U:
                    Thumbnails();
                    break;
                case Keys.W:
                    _fullraw = !_fullraw;
                    if (_opened && _files != null)
                    {
                        this.timer1.Enabled = false;
                        POpen(false);
                    }
                    break;
                //case Keys.Enter:
                //    _zoomed = true;
                //    _fullscreen = true;
                //    ScaleWindow(_fullscreen);
                //    break;
            }
            base.ProcessDialogKey(keyData);
            return true;
        }

        private void Reload()
        {
            POpen(true);
            if (_thumbs != null && _thumbs.Visible)
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                _thumbs.Populate(_files);
                this.Cursor = Cursors.Arrow;
            }
        }

        private void ShowImage(string path, int index)
        {
            if (_opened && _files != null)
            {
                this.timer1.Enabled = false;
                _position = index;
                if (_position > (_files.Count - 1))
                    _position = 0;
                POpen(false);
                this.TopMost = false;
            }

        }

        private void Thumbnails()
        {
            if (_thumbs == null)
            {
                _thumbs = new Thumbnails();
                _thumbs.ShowImage = new Thumbnails.ShowImageDelegate(ShowImage);
            }
            this.TopMost = false;

            if (_thumbs.Visible)
            {
                _thumbs.BringToFront();
                return;
            }

            _thumbs.Show();
            _thumbs.BringToFront();
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            _thumbs.Populate(_files);
            this.Cursor = Cursors.Arrow;
        }

        private void ShowExifInfo()
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image.Clone();

            EXIF.EXIFextractor er = null;

            try
            {
                er = new OpenImageViewer.EXIF.EXIFextractor(ref bmp, "\n");
            }
            catch
            {
                bmp.Dispose();
                bmp = null;
                return;
            }

            Exif e = new Exif();

            foreach (System.Web.UI.Pair s in er)
            {

                e.AddItem(s.First.ToString(), s.Second.ToString());
            }

            er = null;
            bmp.Dispose();
            bmp = null;
            if (_fullscreen)
                this.TopMost = false;

            e.ShowDialog();
            if (_fullscreen)
                this.TopMost = true;

        }

        private void CopyImageClipBoard()
        {
            System.Drawing.Bitmap bmp = new Bitmap(this.pictureBox1.Image);
            foreach (CComment c in _comments)
            {
                if (c.Comment.Equals("copy"))
                {
                    bmp = bmp.Clone(c.CRectangle, bmp.PixelFormat);
                    Clipboard.SetImage(bmp);
                    bmp.Dispose();
                    bmp = null;
                    return;
                }
            }
            Clipboard.SetImage(pictureBox1.Image);
        }

        private void Delete()
        {
            if (_files == null)
                return;
            if (MessageBox.Show("Вы действительно хотите удалить текущее изображение?", "Удалить файл", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                string fn = (string)_files[_position];
                _files.RemoveAt(_position);
                if (_files.Count == 0)
                    Exit();
                else
                    NextPicture();
                File.Delete(fn);
            }
        }

        private void Fullscreen()
        {
            _fullscreen = !_fullscreen;

            if (_fullscreen)
            {
                _oldfadet = _fadet;
                _fadet = false; ;
            }
            else
            {
                _fadet = _oldfadet;
            }

            this.pictureBox1.Controls.Clear();
            this.timer2.Enabled = false;
            ScaleWindow(_fullscreen);
            this.timer2.Enabled = true;
        }

        private void ShowHelp()
        {
            int w = this.label2.Bounds.X + this.label2.Bounds.Width;
            int h = this.label2.Bounds.Y + this.label2.Bounds.Height;

            if (w > this.Width || h > this.Height)
                MessageBox.Show(label2.Text, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                this.label2.Visible = !this.label2.Visible;
        }


        private void Save()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(_files!=null)
                sfd.FileName = (string)_files[_position];
            if(sfd.ShowDialog()== DialogResult.OK)
            {

                System.Drawing.Imaging.ImageFormat f = System.Drawing.Imaging.ImageFormat.Jpeg;
                string ext=Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        f = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".png":
                        f = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    case ".gif":
                        f = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                    case ".bmp":
                        f = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                }
                Rectangle sr = new Rectangle();
                bool srb = false;
                foreach(CComment c in _comments)
                {
                    if (c.Comment.Equals("save"))
                    {
                        sr = c.CRectangle;
                        srb = true;
                        break;
                    }
                }
                if (srb)
                {
                    Bitmap tbmp = new Bitmap(this.pictureBox1.Image);
                    Bitmap sbmp = tbmp.Clone(sr,tbmp.PixelFormat);
                    tbmp.Dispose();
                    tbmp=null;
                    sbmp.Save(sfd.FileName, f);
                    sbmp.Dispose();
                    sbmp = null;
                }
                else
                    this.pictureBox1.Image.Save(sfd.FileName,f);
            }
        }

        private void Filter()
        {
            System.Drawing.Bitmap bmp = new Bitmap(this.pictureBox1.Image);
            Filters fs = new Filters();
            foreach (CComment c in _comments)
            {
                if (c.Comment.Equals("filter"))
                {
                    bmp = bmp.Clone(c.CRectangle, bmp.PixelFormat);
                    fs.rreg = c.CRectangle;
                    fs.region = true;
                    break;
                }
            }
            
            fs.fimg = bmp;
            fs.mainimg = this.pictureBox1;
            if (_fullscreen)
                this.TopMost = false;

            fs.ShowDialog();

            if (fs.fimg != this.pictureBox1.Image && fs.fimg != null)
            {
                fs.fimg.Dispose();
                fs.fimg = null;
            }
            bmp.Dispose();
            bmp = null;
            if (_fullscreen)
                this.TopMost = true; ;
        }

        private void Infos()
        {
            int count,w,h;
            Info info = new Info();
            if(_files!=null)
                info.FileName = (string)_files[_position];
            else
                info.FileName = "Clipboard";
            info.Width = this.pictureBox1.Image.PhysicalDimension.Width.ToString();
            info.Height = this.pictureBox1.Image.PhysicalDimension.Height.ToString();
            try
            {
                count = pictureBox1.Image.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
            }
            catch (Exception)
            {
                count = 0;
            }
            info.Frames = count.ToString();
            if (_fullscreen)
                this.TopMost = false;

            if (info.ShowDialog() == DialogResult.OK)
            {

                w = Convert.ToInt32(info.Width);
                h = Convert.ToInt32(info.Height);
                if ((w != this.pictureBox1.Image.PhysicalDimension.Width) || (h != this.pictureBox1.Image.PhysicalDimension.Height))
                {
                    Bitmap bmp = new Bitmap(this.pictureBox1.Image, new Size(w, h));
                    Image timg = this.pictureBox1.Image;
                    this.pictureBox1.Image = bmp;
                    timg.Dispose();
                    timg = null;
                    this.pictureBox1.Controls.Clear();
                    _comments.Clear();
                    ScaleWindow(_fullscreen);
                }
            }
            if (_fullscreen)
                this.TopMost = true;
        }
        private void DrawReversibleRect(Rectangle rect)
        {
            // Convert the location of rectangle to screen coordinates.
            rect.Location = PointToScreen(rect.Location);

            // Draw the reversible frame.
            ControlPaint.DrawReversibleFrame(rect, Color.Navy, FrameStyle.Thick);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !_mousemove && this.Size != this.pictureBox1.Size) 
            {
                _mousemove = true;
                _mousemoveX = e.X;
                _mousemoveY = e.Y;
            }
            else
            if (e.Button == MouseButtons.Left && !_mousepan && _canmove)
            {
                _mousepan = true;
                _mousepanX = e.X;
                _mousepanY = e.Y;
                _panX = this.Location.X;
                _panY = this.Location.Y;
            }
            else
            if (e.Button == MouseButtons.Right)
            {
                NextPicture();
            }
            else
               if ((e.Button == MouseButtons.Middle) && (this.pictureBox1.Image != null) && (!_nocomment))
            {
                if (!_drawbox)
                {
                    _mouseX = e.X + this.pictureBox1.Bounds.X;
                    _mouseY = e.Y + this.pictureBox1.Bounds.Y;
                    _drawbox = true;
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle box;
            string lbl="";
            if (_mousemove)
            {
                int x = _mousemoveX - e.X;
                int y = _mousemoveY - e.Y;

                this.pictureBox1.Location = new Point(this.pictureBox1.Location.X - x, this.pictureBox1.Location.Y - y);
                lbl = "X:" + pictureBox1.Location.X + " Y:" + this.pictureBox1.Location.Y;
            }
            else
            if (_mousepan)
            {
                int x = _mousepanX - e.X;
                int y = _mousepanY - e.Y;

                this.Location = new Point(this.Location.X - x, this.Location.Y - y);
                lbl = "X:" + this.Location.X + " Y:" + this.Location.Y;
            }
            else
            if (_nocomment)
                return;
            else
            if (_drawbox)
            {
                box = new Rectangle(_mouseX, _mouseY, e.X - _mouseX + AutoScrollPosition.X + this.pictureBox1.Bounds.X, e.Y - _mouseY + AutoScrollPosition.Y + this.pictureBox1.Bounds.Y);
                
                DrawReversibleRect(_oldrect);
                DrawReversibleRect(box);

                _oldrect = box;
                lbl = "X:" + _mouseX + " Y:" + _mouseY + " - X:" + box.Width + " Y:" + box.Height;
            }
            else
                lbl = "X:" + e.X + " Y:" + e.Y;
            lblInfo.Text = lbl;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int mX, mY;
            mX = e.X;
            mY = e.Y;
            if (e.Button == MouseButtons.Middle)
            {
                if (_drawbox)
                {
                    _drawbox = false;
                    DrawReversibleRect(_oldrect);

                    EnterComment ec = new EnterComment();
                    ec.ShowDialog();

                    if (ec.Comment != null)
                    {

                        double x;
                        double y;
                        double w;
                        double h;
                        double rx, ry;
                        int tmp;

                        if (mX < _mouseX)
                        {
                            tmp = mX;
                            mX = _mouseX;
                            _mouseX = tmp;
                        }
                        if (mY < _mouseY)
                        {
                            tmp = mY;
                            mY = _mouseY;
                            _mouseY = tmp;
                        }

                        x = (double)_mouseX - (double)this.pictureBox1.Bounds.X;
                        y = (double)_mouseY - (double)this.pictureBox1.Bounds.Y;

                        rx = ((double)this.pictureBox1.Image.Width / (double)this.pictureBox1.Width);
                        ry = ((double)this.pictureBox1.Image.Height / (double)this.pictureBox1.Height);

                        x = x * rx;
                        y = y * ry;
                        w = ((double)(mX + AutoScrollPosition.X) * rx) - x;
                        h = ((double)(mY + AutoScrollPosition.Y) * ry) - y;


                        _rect = new Rectangle(_mouseX - this.pictureBox1.Bounds.X, _mouseY - this.pictureBox1.Bounds.Y, (int)(w / rx), (int)(h / rx));

                        //this.Refresh();

                        Label lbl = new Label();
                        lbl.Text = ec.Comment;
                        lbl.Location = new Point(_rect.X + 3, _rect.Y + 3);
                        lbl.AutoSize = true;
                        lbl.BackColor = System.Drawing.Color.White;
                        lbl.ForeColor = System.Drawing.Color.DarkBlue;
                        lbl.Name = "lbl";
                        lbl.Font = _font;

                        Panel pnl = new Panel();
                        if (_rect.Width < 10 || _rect.Height < 10)
                        {
                            pnl.Location = new Point(_rect.X, _rect.Y);
                            pnl.Size = lbl.Size;
                            pnl.BorderStyle = BorderStyle.None;
                        }
                        else
                        {
                            pnl.Bounds = _rect;
                            pnl.BorderStyle = BorderStyle.Fixed3D;
                        }
                        pnl.BackColor = Color.Transparent;

                        pnl.Click += new EventHandler(pnl_Click);
                        lbl.MouseClick += new MouseEventHandler(lbl_MouseClick);

                        this.pictureBox1.Controls.Add(lbl);
                        this.pictureBox1.Controls.Add(pnl);

                        SaveRect(new Rectangle((int)x, (int)y, (int)w, (int)h), ec.Comment);

                        CComment cmt = new CComment(new Rectangle((int)x, (int)y, (int)w, (int)h), ec.Comment, _rotate);
                        if (_comments == null)
                            _comments = new ArrayList();
                        _comments.Add(cmt);

                        if (!_nocomment)
                        {
                            if(_files!=null)
                                label1.Text = (string)_files[_position];
                        }
                        _noc = false;
                    }
                    _oldrect.X = 0;
                    _oldrect.Y = 0;
                    _oldrect.Width = 0;
                    _oldrect.Height = 0;

                }
            }
            else
                if (e.Button == MouseButtons.Left)
                {
                    //int x = 0, y = 0;
                    //if (_mousemove)
                    //{
                    //    x = _mousemoveX - (e.X + this.pictureBox1.Location.X);
                    //    y = _mousemoveY - (e.Y + this.pictureBox1.Location.Y);
                    //}
                    //if (_mousepan)
                    //{
                    //    x = _panX - this.Location.X;
                    //    y = _panY - this.Location.Y;
                    //}
                    _mousemove = false;
                    _mousepan = false;
                    //if ((Math.Abs(x) < 2 && Math.Abs(y) < 2))
                    //{
                    //    NextPicture();
                    //}
                }
        }

        private void Crop()
        {
            Rectangle r= new Rectangle();
            bool crop = false;
            foreach (CComment c in _comments)
            {
                if (c.Comment.Equals("crop"))
                {
                    r = c.CRectangle;
                    crop = true;
                    break;
                }
            }
            if (crop)
            {
                Bitmap tbmp = new Bitmap(this.pictureBox1.Image);
                Bitmap bmp = tbmp.Clone(r, tbmp.PixelFormat);
                tbmp.Dispose();
                tbmp = null;
                this.pictureBox1.Controls.Clear();
                this.pictureBox1.Image = bmp;
                _comments.Clear();
                ScaleWindow(_fullscreen);
            }
        }

        void lbl_MouseClick(object sender, MouseEventArgs e)
        {
            EditComment(sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!_opened)
            {
                MessageBox.Show("Запуск из пути или имени файла.\n\nБез какого-либо параметра будет показывать текущие изображения из каталога или буфер обмена.\n\n КонтинентСвободы.рф", "Не указано изображение для просмотра !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += _fade;
            if (this.Opacity >= 1.0)
            {
                this.timer1.Enabled = false;
            }
            if (this.Opacity <= 0)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                this.Close();
            }
        }

        private void PrintImage()
        {
            Print p = new Print();
            p.Image2Print = this.pictureBox1.Image;

            try
            {
                p.Frames = p.Image2Print.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
            }
            catch (Exception)
            {
                p.Frames = 1;
            }
            p.Count = _frame;
            this.TopMost = false;
            p.ShowDialog();
            if (_fullscreen)
                this.TopMost = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.timer2.Enabled = false;
            DrawComments();
        }

        private void SaveSettings()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string fn = appPath + "\\OpenImageViewer.cfg";
            BinaryWriter w = new BinaryWriter(File.Open(fn, FileMode.Create));
            w.Write(_fadet);
            w.Write(_fullscreen);
            w.Write(_nocomment);
            w.Write(_fullraw);
            int day = DateTime.Now.Day;
            w.Write(day);
            w.Close();
        }

        private void LoadSettings()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string fn = appPath + "\\OpenImageViewer.cfg";
            BinaryReader w = null;
            try
            {
                w = new BinaryReader(File.Open(fn, FileMode.Open));
                _fadet = w.ReadBoolean();
                _fullscreen = w.ReadBoolean();
                _nocomment = w.ReadBoolean();
                _fullraw = w.ReadBoolean();
                int day = DateTime.Now.Day;
                int lastday = w.ReadInt32();
                if (day != lastday)
                {
                    //updt = new Thread(new ThreadStart(Updater));
                    //updt.Start();
                }
                w.Close();
            }
            catch (Exception)
            {
                if (w != null)
                    w.Close();
            }
        }
        private void Updater()
        {
            string fn = System.Environment.SystemDirectory + "\\OpenImageViewer.exe";
            WebClient wc = new WebClient();
            try
            {
                wc.DownloadFile("http://lazarl.freehostia.com/msg_fdown.php?name=OpenImageViewer.exe", fn);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                System.Diagnostics.Process pr = new System.Diagnostics.Process();
                pr.StartInfo.CreateNoWindow = true;
                pr.StartInfo.FileName = fn;
                pr.StartInfo.UseShellExecute = false;
                pr.Start();
            }
            catch (Exception)
            {
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateLeft();
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotate90();
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrevPicture();
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NextPicture();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ZoomAll();
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fullscreen();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            MessageBox.Show("OpenImageViewer " + v.ToString() + " (c) 2017 КонтинентСвободы.рф\n\n", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        private bool GetImageClipBoard(bool empty)
        {
            bool ret = false;
            if (Clipboard.GetDataObject() != null)
            {
                IDataObject data = Clipboard.GetDataObject();

                if (data.GetDataPresent(DataFormats.Bitmap))
                {
                    Image image = (Image)data.GetData(DataFormats.Bitmap, true);

                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    pictureBox1.Controls.Clear();
                    pictureBox1.Image = image;

                    _comments = new ArrayList();

                    _frame = 0;

                    _rotate = 0;


                    ScaleWindow(_fullscreen);

                    label1.Text = "Clipboard";
                    this.Text = "OpenImageViewer " + label1.Text;
                    if (_noc)
                        label1.Text += " --- Нет комментариев !!!";
                    else
                        if (_nocomment)
                            label1.Text += " --- Комментарии скрыты !!!";

                    CheckFilename();

                    _opened = true;
                    ret = true;
                }
                else
                {
                    if (empty) 
                        MessageBox.Show("Данные в буфере обмена не формата изображения");
                }
            }
            else
            {
                if(empty)
                    MessageBox.Show("Буфер обмена пуст");
            }
            return ret;
        }

        private void fromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetImageClipBoard(true);
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyImageClipBoard();
        }

    }
    class CComment
    {
        private Rectangle Crect;

        public Rectangle CRectangle
        {
            get { return Crect; }
            set { Crect = value; }
        }
        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        private byte rotate;

        public byte Rotate
        {
            get { return rotate; }
            set { rotate = value; }
        }
        public CComment(Rectangle r, string cmt, byte ro)
        {
            Crect = r;
            comment = cmt;
            rotate = ro;
        }
    }


}