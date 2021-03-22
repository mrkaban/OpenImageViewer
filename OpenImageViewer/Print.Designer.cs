namespace OpenImageViewer
{
    partial class Print
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print));
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rbFullPage = new System.Windows.Forms.RadioButton();
            this.bPreview = new System.Windows.Forms.Button();
            this.bPrint = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.rbFZoom = new System.Windows.Forms.RadioButton();
            this.bPage = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(12, 12);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(40, 17);
            this.rb1.TabIndex = 0;
            this.rb1.Text = "1:1";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // rbFullPage
            // 
            this.rbFullPage.AutoSize = true;
            this.rbFullPage.Location = new System.Drawing.Point(12, 35);
            this.rbFullPage.Name = "rbFullPage";
            this.rbFullPage.Size = new System.Drawing.Size(96, 17);
            this.rbFullPage.TabIndex = 1;
            this.rbFullPage.Text = "Все страницы";
            this.rbFullPage.UseVisualStyleBackColor = true;
            // 
            // bPreview
            // 
            this.bPreview.Location = new System.Drawing.Point(104, 38);
            this.bPreview.Name = "bPreview";
            this.bPreview.Size = new System.Drawing.Size(96, 23);
            this.bPreview.TabIndex = 2;
            this.bPreview.Text = "Пред просмотр";
            this.bPreview.UseVisualStyleBackColor = true;
            this.bPreview.Click += new System.EventHandler(this.bPreview_Click);
            // 
            // bPrint
            // 
            this.bPrint.Location = new System.Drawing.Point(104, 67);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(96, 23);
            this.bPrint.TabIndex = 3;
            this.bPrint.Text = "Печать";
            this.bPrint.UseVisualStyleBackColor = true;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(69, 112);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Закрыть";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // rbFZoom
            // 
            this.rbFZoom.AutoSize = true;
            this.rbFZoom.Checked = true;
            this.rbFZoom.Location = new System.Drawing.Point(12, 58);
            this.rbFZoom.Name = "rbFZoom";
            this.rbFZoom.Size = new System.Drawing.Size(87, 17);
            this.rbFZoom.TabIndex = 5;
            this.rbFZoom.TabStop = true;
            this.rbFZoom.Text = "Полный зум";
            this.rbFZoom.UseVisualStyleBackColor = true;
            // 
            // bPage
            // 
            this.bPage.Location = new System.Drawing.Point(104, 9);
            this.bPage.Name = "bPage";
            this.bPage.Size = new System.Drawing.Size(96, 23);
            this.bPage.TabIndex = 6;
            this.bPage.Text = "Страница";
            this.bPage.UseVisualStyleBackColor = true;
            this.bPage.Click += new System.EventHandler(this.bPage_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 89);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Печать всех страниц";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Print
            // 
            this.AcceptButton = this.bPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(212, 147);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.bPage);
            this.Controls.Add(this.rbFZoom);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.bPreview);
            this.Controls.Add(this.rbFullPage);
            this.Controls.Add(this.rb1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Print";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Печать";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rbFullPage;
        private System.Windows.Forms.Button bPreview;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Button bCancel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.RadioButton rbFZoom;
        private System.Windows.Forms.Button bPage;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}