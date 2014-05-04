namespace gis
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.caidanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开e00文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开栅格文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存栅格文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.栅格文件另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.矢量转栅格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示矢量图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示栅格图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示矢量栅格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caidanToolStripMenuItem,
            this.转换ToolStripMenuItem,
            this.显示ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(663, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // caidanToolStripMenuItem
            // 
            this.caidanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开e00文件ToolStripMenuItem,
            this.打开栅格文件ToolStripMenuItem,
            this.保存栅格文件ToolStripMenuItem,
            this.栅格文件另存为ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.caidanToolStripMenuItem.Name = "caidanToolStripMenuItem";
            this.caidanToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.caidanToolStripMenuItem.Text = "文件";
            // 
            // 打开e00文件ToolStripMenuItem
            // 
            this.打开e00文件ToolStripMenuItem.Name = "打开e00文件ToolStripMenuItem";
            this.打开e00文件ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.打开e00文件ToolStripMenuItem.Text = "打开e00文件";
            this.打开e00文件ToolStripMenuItem.Click += new System.EventHandler(this.打开e00文件ToolStripMenuItem_Click);
            // 
            // 打开栅格文件ToolStripMenuItem
            // 
            this.打开栅格文件ToolStripMenuItem.Name = "打开栅格文件ToolStripMenuItem";
            this.打开栅格文件ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.打开栅格文件ToolStripMenuItem.Text = "打开栅格文件";
            this.打开栅格文件ToolStripMenuItem.Click += new System.EventHandler(this.打开栅格文件ToolStripMenuItem_Click);
            // 
            // 保存栅格文件ToolStripMenuItem
            // 
            this.保存栅格文件ToolStripMenuItem.Name = "保存栅格文件ToolStripMenuItem";
            this.保存栅格文件ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.保存栅格文件ToolStripMenuItem.Text = "保存栅格文件";
            this.保存栅格文件ToolStripMenuItem.Click += new System.EventHandler(this.保存栅格文件ToolStripMenuItem_Click);
            // 
            // 栅格文件另存为ToolStripMenuItem
            // 
            this.栅格文件另存为ToolStripMenuItem.Name = "栅格文件另存为ToolStripMenuItem";
            this.栅格文件另存为ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.栅格文件另存为ToolStripMenuItem.Text = "栅格文件另存为";
            this.栅格文件另存为ToolStripMenuItem.Click += new System.EventHandler(this.栅格文件另存为ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.退出ToolStripMenuItem.Text = "    退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 转换ToolStripMenuItem
            // 
            this.转换ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.矢量转栅格ToolStripMenuItem});
            this.转换ToolStripMenuItem.Name = "转换ToolStripMenuItem";
            this.转换ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.转换ToolStripMenuItem.Text = "转换";
            // 
            // 矢量转栅格ToolStripMenuItem
            // 
            this.矢量转栅格ToolStripMenuItem.Name = "矢量转栅格ToolStripMenuItem";
            this.矢量转栅格ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.矢量转栅格ToolStripMenuItem.Text = "矢量转栅格";
            this.矢量转栅格ToolStripMenuItem.Click += new System.EventHandler(this.矢量转栅格ToolStripMenuItem_Click);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示矢量图像ToolStripMenuItem,
            this.显示栅格图像ToolStripMenuItem,
            this.显示矢量栅格ToolStripMenuItem});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.显示ToolStripMenuItem.Text = "显示";
            // 
            // 显示矢量图像ToolStripMenuItem
            // 
            this.显示矢量图像ToolStripMenuItem.Name = "显示矢量图像ToolStripMenuItem";
            this.显示矢量图像ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.显示矢量图像ToolStripMenuItem.Text = "显示矢量图像";
            this.显示矢量图像ToolStripMenuItem.Click += new System.EventHandler(this.显示矢量图像ToolStripMenuItem_Click);
            // 
            // 显示栅格图像ToolStripMenuItem
            // 
            this.显示栅格图像ToolStripMenuItem.Name = "显示栅格图像ToolStripMenuItem";
            this.显示栅格图像ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.显示栅格图像ToolStripMenuItem.Text = "显示栅格图像";
            this.显示栅格图像ToolStripMenuItem.Click += new System.EventHandler(this.显示栅格图像ToolStripMenuItem_Click);
            // 
            // 显示矢量栅格ToolStripMenuItem
            // 
            this.显示矢量栅格ToolStripMenuItem.Name = "显示矢量栅格ToolStripMenuItem";
            this.显示矢量栅格ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.显示矢量栅格ToolStripMenuItem.Text = "显示矢量+栅格";
            this.显示矢量栅格ToolStripMenuItem.Click += new System.EventHandler(this.显示矢量栅格ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem1,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            this.帮助ToolStripMenuItem1.Click += new System.EventHandler(this.帮助ToolStripMenuItem1_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(40, 406);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.trackBar1.Maximum = 300;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(555, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(17, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 377);
            this.panel1.TabIndex = 3;
            this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(63, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(455, 311);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "放大";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "缩小";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 436);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem caidanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开e00文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开栅格文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存栅格文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 矢量转栅格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示矢量图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示栅格图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示矢量栅格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 栅格文件另存为ToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

