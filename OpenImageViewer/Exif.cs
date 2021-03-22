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
    public partial class Exif : Form
    {
        public Exif()
        {
            InitializeComponent();
        }

        public void AddItem(string name, string val)
        {
            ListViewItem lvi = new ListViewItem(name);
            lvi.SubItems.Add(val);
            listView1.Items.Add(lvi);
        }
    }
}
