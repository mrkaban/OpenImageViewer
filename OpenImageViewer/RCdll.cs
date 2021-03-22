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
using System.Text;
using System.Runtime.InteropServices;

namespace OpenImageViewer
{
    struct OutParam
    {
        public string fn;
        public int ret;
        public string error;
    }
    class RCdll
    {
        [DllImport("rawconverter.dll")]
        public static extern void Convert(string fn_in, string fn_out, string fn_tb, int cam_wb, int auto_wb);

        [DllImport("rawconverter.dll")]
        public static extern void Finish();

        [DllImport("rawconverter.dll")]
        public static extern IntPtr Response();

        [DllImport("rawconverter.dll")]
        public static extern bool LoadRaw(string fn, int camwb, int autowb, IntPtr buf, int stride);

        [DllImport("rawconverter.dll")]
        public static extern void FreeImage();

        [DllImport("rawconverter.dll")]
        public static extern bool GetSize(string fn, ref int width, ref int height, ref int tsize);

        [DllImport("rawconverter.dll")]
        public static extern bool LoadThumb(string fn, IntPtr buf);

        [DllImport("rawconverter.dll")]
        public static extern bool SaveThumb(string fn, string tmp);
    }
}
