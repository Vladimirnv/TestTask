namespace cam
{
    partial class CamReader
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LTBox = new System.Windows.Forms.PictureBox();
            this.RTBox = new System.Windows.Forms.PictureBox();
            this.LBBox = new System.Windows.Forms.PictureBox();
            this.RBBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LTBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LBBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RBBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.LTBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RTBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LBBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.RBBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 385);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LTBox
            // 
            this.LTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LTBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LTBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LTBox.Location = new System.Drawing.Point(3, 3);
            this.LTBox.Name = "LTBox";
            this.LTBox.Size = new System.Drawing.Size(360, 186);
            this.LTBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LTBox.TabIndex = 0;
            this.LTBox.TabStop = false;
            this.LTBox.Tag = "0";
            this.LTBox.Click += new System.EventHandler(this.Run);
            // 
            // RTBox
            // 
            this.RTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RTBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTBox.Location = new System.Drawing.Point(369, 3);
            this.RTBox.Name = "RTBox";
            this.RTBox.Size = new System.Drawing.Size(360, 186);
            this.RTBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RTBox.TabIndex = 1;
            this.RTBox.TabStop = false;
            this.RTBox.Tag = "1";
            this.RTBox.Click += new System.EventHandler(this.Run);
            // 
            // LBBox
            // 
            this.LBBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LBBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBBox.Location = new System.Drawing.Point(3, 195);
            this.LBBox.Name = "LBBox";
            this.LBBox.Size = new System.Drawing.Size(360, 187);
            this.LBBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LBBox.TabIndex = 2;
            this.LBBox.TabStop = false;
            this.LBBox.Tag = "2";
            this.LBBox.Click += new System.EventHandler(this.Run);
            // 
            // RBBox
            // 
            this.RBBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RBBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RBBox.Location = new System.Drawing.Point(369, 195);
            this.RBBox.Name = "RBBox";
            this.RBBox.Size = new System.Drawing.Size(360, 187);
            this.RBBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RBBox.TabIndex = 3;
            this.RBBox.TabStop = false;
            this.RBBox.Tag = "3";
            this.RBBox.Click += new System.EventHandler(this.Run);
            // 
            // CamReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 385);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CamReader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LTBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LBBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RBBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox LTBox;
        private System.Windows.Forms.PictureBox RTBox;
        private System.Windows.Forms.PictureBox LBBox;
        private System.Windows.Forms.PictureBox RBBox;
    }
}

