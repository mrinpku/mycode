using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace gis
{
    public partial class Form1 : Form
    {
        static public E00 e00;
        static public Grid grid;  //此处用公有解决真是好奇怪
        static bool isE00Empty = true;
        static bool isGridEmpty = true;
       // static bool isE00Saved = false;
        static bool isGridSaved = false;    
        public Form1()
        {
            InitializeComponent();
            this.Show();
            //Pen pen = new Pen(Color.Black, 1);
        }

        private void 打开e00文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();//实例化  
            //Filter 允许打开文件的格式  显示在Dialg中的Files of Type  
            openFileDialog1.Filter = "E00 files (*.e00)|*.e00";
            //显示在Dialg中的Files of Type的选择  
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Choose E00 File";
            openFileDialog1.ShowDialog();

            StreamReader e00_file = null;
            try
            {
                if (openFileDialog1.FileName == "")
                    return;
                e00_file = new StreamReader(openFileDialog1.FileName);
                e00 = new E00(e00_file);
                isE00Empty = false;
                //isE00Saved = false;
            }
            catch (IOException exp)
            {

                MessageBox.Show(exp.Message);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isGridSaved)
            {
                DialogResult dr = MessageBox.Show("栅格文件未保存！是否继续","警告",MessageBoxButtons.YesNo);
                if(dr ==DialogResult.No)
                    return;
            }
            Dispose();
        }

        private void 打开栅格文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //提醒保存已有文件
            if (!isGridSaved&&grid!=null)
            {
                DialogResult dr = MessageBox.Show("是否保存已有栅格文件?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (dr == DialogResult.Yes)
                    saveGridFile();
             }
            //
            OpenFileDialog openFileDialog1 = new OpenFileDialog();//实例化  
            //Filter 允许打开文件的格式  显示在Dialg中的Files of Type  
            openFileDialog1.Filter = "Grid files (*.grid)|*.grid";
            //显示在Dialg中的Files of Type的选择  
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Choose Grid File";
            openFileDialog1.ShowDialog();
            
            StreamReader grid_file = null;
            try
            {
                if (openFileDialog1.FileName == "")
                    return;
                grid_file = new StreamReader(openFileDialog1.FileName);
                grid = new Grid(grid_file);
                isGridEmpty = false;
                isGridSaved = true;
            }
            catch (IOException exp)
            {

                MessageBox.Show(exp.Message);
            }
            
        }

        private void 保存栅格文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //设置判断
            if (isGridSaved)
            {
                MessageBox.Show("文件已保存");
            }
            else if (isGridEmpty)
            {
                MessageBox.Show("不存在栅格文件");
            }
            else
            {
                saveGridFile();
                MessageBox.Show("文件保存成功");
            }
          
        }

        private void 栅格文件另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGridEmpty)
            {
                MessageBox.Show("不存在栅格文件");
            }
            saveGridFile();
            MessageBox.Show("文件保存成功");
        }
        
        private void saveGridFile()
        {
            SaveFileDialog sf = new SaveFileDialog();
            //设置文件保存类型
            sf.Filter = "grid文件|*.grid";
            //如果用户没有输入扩展名，自动追加后缀
            sf.AddExtension = true;
            //设置标题
            sf.Title = "保存栅格文件";
            //如果用户点击了保存按钮
            if (sf.ShowDialog() == DialogResult.OK)
            {
                //实例化一个文件流--->与写入文件相关联
                FileStream fs = new FileStream(sf.FileName, FileMode.Create);
                //实例化一个StreamWriter-->与fs相关联
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                grid.Save(sw);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
                isGridSaved = true;
            }
        }

        private void 矢量转栅格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isE00Empty)
            {
                MessageBox.Show("未读入E00文件");
                return;
            }
            if (!isGridEmpty)
            {
                DialogResult dr = MessageBox.Show("已经存在栅格文件，是否重新转换", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (dr == DialogResult.No)
                    return;
                else
                    if (!isGridSaved)
                    {
                        DialogResult dr1 = MessageBox.Show("是否保存现有栅格文件", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                        if (dr1 == DialogResult.Yes)
                            saveGridFile();
                     
                    }
            }
            栅格化设置 temp = new 栅格化设置();
            temp.ShowDialog();
            isGridEmpty = false;
            isGridSaved = false;
            MessageBox.Show("转换完毕");
            //grid = new Grid(e00);
        }

        private void 显示矢量图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isE00Empty)
            {
                MessageBox.Show("未读入E00文件");
                return;
            }
            pictureBox1.Visible = true;
            显示栅格图像ToolStripMenuItem.Checked = false;
            显示矢量栅格ToolStripMenuItem.Checked = false;
            if (显示矢量图像ToolStripMenuItem.Checked == false)
            {
                originWidth = pictureBox1.Width;
                originHeight = pictureBox1.Height;
                显示矢量图像ToolStripMenuItem.Checked = true;
                pictureBox1.Refresh();
            }
            else
            {
                显示矢量图像ToolStripMenuItem.Checked = false;
                pictureBox1.Refresh();
            }
        }

        private void 显示栅格图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGridEmpty)
            {
                MessageBox.Show("不存在栅格数据");
                return;
            }
            pictureBox1.Visible = true;
            显示矢量栅格ToolStripMenuItem.Checked = false;
            显示矢量图像ToolStripMenuItem.Checked = false;
            if (显示栅格图像ToolStripMenuItem.Checked == false)
            {

                显示栅格图像ToolStripMenuItem.Checked = true;
                pictureBox1.Size = grid.ToBitmap().Size;
                //pictureBox1.Width = (int)(grid.ToBitmap().Width * 1.1);
                //pictureBox1.Height = (int)(grid.ToBitmap().Height * 1.1);
                originWidth = pictureBox1.Width;
                originHeight = pictureBox1.Height;
                pictureBox1.Image = grid.bitmap;
                pictureBox1.Refresh();
             }
            //else if(显示矢量栅格ToolStripMenuItem.Checked == false)
            //{
            //    显示栅格图像ToolStripMenuItem.Checked = false;
            //    pictureBox1.Image = null;
            //    pictureBox1.Refresh();
            //}
            else
            {
                显示栅格图像ToolStripMenuItem.Checked = false;
                pictureBox1.Image = null;
                pictureBox1.Refresh();
            }
            
            //pictureBox1.Refresh();
           // pictureBox1.Invalidate();
           // Graphics g = pictureBox1.CreateGraphics();
          //  pictureBox1.Show();
           // grid.display(g);
        }

        private void 显示矢量栅格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGridEmpty)
            {
                MessageBox.Show("不存在栅格数据");
                return;
            }
            if (isE00Empty)
            {
                MessageBox.Show("未读入E00文件");
                return;
            }
            pictureBox1.Visible = true;
            显示矢量图像ToolStripMenuItem.Checked = false;
            显示栅格图像ToolStripMenuItem.Checked = false;
            if (显示矢量栅格ToolStripMenuItem.Checked == false)
            {
                pictureBox1.Size = grid.ToBitmap().Size;
                //pictureBox1.Width = (int)(grid.ToBitmap().Width * 1.1);
                //pictureBox1.Height = (int)(grid.ToBitmap().Height * 1.1);
                
                originWidth = pictureBox1.Width;
                originHeight = pictureBox1.Height;
                pictureBox1.Image = grid.bitmap;
                显示矢量栅格ToolStripMenuItem.Checked = true;
                pictureBox1.Refresh();
            }
            else
            {
                显示矢量栅格ToolStripMenuItem.Checked = false;
                pictureBox1.Image = null;
                pictureBox1.Refresh();
            }
            //Graphics g = pictureBox1.CreateGraphics();
            //e00.display(g);
            //grid.display(g);
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GIS概论大作业 矢量转栅格小程序\n\n        苗睿 1200012426");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            e.Graphics.PageScale = 1;
            if (显示矢量图像ToolStripMenuItem.Checked)
            {
                float ratio =
                    pictureBox1.Height / e00.PALList[0].height() < pictureBox1.Width / e00.PALList[0].width()
                    ? pictureBox1.Height / e00.PALList[0].height()/1.1F : pictureBox1.Width / e00.PALList[0].width()/1.1F;
                //ratio *= 0.99F;
                e.Graphics.ScaleTransform(ratio, ratio);

                //g.TranslateTransform(5, 5); //改变原点？留用
                //e.Graphics.DrawLine(new Pen(Color.Red, 5), 1, 1, 1000, 1000);


                Pen pen = new Pen(Color.Black, 1);
                for (int i = 0; i < e00.ARCList.Count; i++)
                {
                    e.Graphics.DrawLines(pen, e00.ARCList[i].pointlist_draw);
                }
            }
            if (显示矢量栅格ToolStripMenuItem.Checked)
            {
                
               // float ratio =
                //    pictureBox1.Width / e00.PALList[0].width();
               // ratio *= 0.99F;
                e.Graphics.ScaleTransform(pictureBox1.Width / e00.PALList[0].width()/1.1F, pictureBox1.Height / e00.PALList[0].height()/1.1F);

               // e.Graphics.TranslateTransform(0, 0); //改变原点？留用
                //e.Graphics.DrawLine(new Pen(Color.Red, 5), 1, 1, 1000, 1000);


                Pen pen = new Pen(Color.Black, 1);
                for (int i = 0; i < e00.ARCList.Count; i++)
                {
                    e.Graphics.DrawLines(pen, e00.ARCList[i].pointlist_draw);
                }
            }
            if (显示栅格图像ToolStripMenuItem.Checked)
            {
               
                
                //pictureBox1.Refresh();
            }
            
          
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBox1.Refresh();
        }

        int originHeight, originWidth;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 0)
            {
                trackBar1.Value = 1;
            }
            pictureBox1.Height = Convert.ToInt32(originHeight * trackBar1.Value / 50.0);
            pictureBox1.Width = Convert.ToInt32(originWidth * trackBar1.Value / 50.0);
            pictureBox1.Refresh();
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("如有任何疑问请联系 mrinpku@gmail.com 或 18811465420");
        }

       

     

      

  
        //protected override void onpaint(painteventargs e)
        //{
        //    //base.onpaint(e);
        //    graphics g;

        //    g = e.graphics;

        //    pen mypen = new pen(color.red);
        //    mypen.width = 1;
        //    g.pageunit = graphicsunit.pixel;
        //   // g.drawline(mypen, 30, 30, 45, 65);
        //    g.drawline(mypen, 1, 1, 500, 500);
        //    g.clear(color.white);
        //    g.scaletransform(0.5f, 1f);
        //    g.drawline(mypen, 1, 1, 500, 500);

        //}

       
      
    }
}
