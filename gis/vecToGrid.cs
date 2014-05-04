using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
namespace gis
{
    /// <summary>
    /// 栅格类
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// 行数
        /// </summary>
        int row;
        /// <summary>
        /// 列数
        /// </summary>
        int column;
        /// <summary>
        /// 栅格大小
        /// </summary>
        float pixelSize;
        /// <summary>
        /// 栅格数据
        /// </summary>
        int[,] gri;
        /// <summary>
        /// 由栅格数据生成的位图数据
        /// </summary>
        public Bitmap bitmap;
        /// <summary>
        /// 将一条给定弧段信息转为栅格数据
        /// </summary>
        /// <param name="temp">一条弧度信息</param>
        /// <param name="gri">栅格数组引用</param>
        /// <returns></returns>
        public int ToGrid(ARC temp,int[,] gri)
        {
            //head、tail代表一条线段首位节点
            PointF head = temp.pointlist_draw[0], tail;
            
            for (int i = 1; i < temp.pointNum; i++)
            {
                tail = temp.pointlist_draw[i];  //bug fixed
               
                #region processGrid
               
                //初步处理数据、获取线段斜率代码段
                #region getSlope
                //声明两个标志变量 mark=1代表斜率为无穷大
                //mark1用来在之后表示循环中坐标的范围
                int mark,mark1;
                mark = 0;
                //斜率
                double slope;

                //由输入的pixelSize调整大小
                double tail_y = tail.Y / pixelSize;
                double tail_x = tail.X / pixelSize;
                double head_y = head.Y / pixelSize;
                double head_x = head.X / pixelSize;
                slope = 1;
                if (tail.X != head.X)
                    slope = (tail.Y - head.Y) / (tail.X - head.X);
                else
                    mark = 1; //斜率为无穷大的话进行标注不计算
                #endregion

                //如果线段上行(注意处理过的坐标与实际坐标相反)
                if (head.Y > tail.Y)
                {
                    for (int j = (int)(tail_y)+1; j < (int)(head_y)+1; j++)
                    {
                        //由斜率和一点坐标算出循环终止的坐标值
                        mark1 = Convert.ToInt32(mark == 0 ? ((j - head_y) / slope + head_x) : head_x) ;
                        for (int k = 0; k < mark1; k++)
                        {
                            gri[k, j] += temp.leftPalNo - temp.rightPalNo;
                        }
                    }
                }
                //线段下行，与上类似
                if (head.Y <= tail.Y)
                {
                    for (int j = (int)(head_y)+1; j < (int)(tail_y)+1; j++)
                    {
                        mark1 = Convert.ToInt32(mark == 0 ? ((j - head_y) / slope + head_x) : head_x) ;
                        for (int k = 0; k < mark1; k++)
                        {
                            gri[k, j] +=  temp.rightPalNo - temp.leftPalNo; //右减左
                        }
                    }
                }
                #endregion

                //尾节点变为头节点 循环继续
                head = tail;

            }
            return 0;
        }
        /// <summary>
        /// 构造函数，用于实现矢量转栅格
        /// </summary>
        /// <param name="e00">读取e00文件后形成的e00类</param>
        /// <param name="numOfRow">切割行数</param>
        public Grid(E00 e00, int numOfPixel)  //mark
        {
            //row = numOfRow;
            //column = Convert.ToInt32(e00.PALList[0].width() / e00.PALList[0].height() * row) +2;
            //gri = new int[column, row];
            //pixelSize = e00.PALList[0].height() / row;  //bug fixed
            pixelSize = numOfPixel;
            
            //行列计算乘上1.1倍，使最终图像可以在pictureBox中完整显示
            row = (int)(1.1*e00.PALList[0].height() / numOfPixel) ;
            column = (int)(1.1*e00.PALList[0].width() / numOfPixel) ;
           
            gri = new int[column, row];
            
            for (int i = 0; i < e00.ARCList.Count; i++)
            {
                ToGrid(e00.ARCList[i], gri); //对每一弧段调用函数进行栅格化
            }
            //string debug = "";
            //for (int i = 0; i <row; i++)
            //{
            //    for (int j = 0; j < column; j++)
            //    {
            //       debug+=convert.tostring(gri[j,i]);
            //       debug += " ";
            //    }
            //    debug += "\n";
            //}
            //messagebox.show(debug);
        }
        /// <summary>
        /// 构造函数2 用于从文件中生成grid类
        /// </summary>
        /// <param name="input">读入文件流</param>
        public Grid(StreamReader input)
        {
            //变量声明
            string[] data;
            string temp;
            char[] splitchar = new char[] {' '};//切分数组
            int j = 0;
            
            //切分读取文件头
            data = input.ReadLine().Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
            if (data.Count() != 2)
            {
                MessageBox.Show("文件格式错误");
                return;
            }
            //初始化文件头信息
            row = Convert.ToInt32(data[0]);
            column = Convert.ToInt32(data[1]);
            gri = new int[column,row];

            //切分读取栅格信息
            while ((temp = input.ReadLine()) != null)
            {
                data = temp.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
                if (data.Count() != column)
                {
                    MessageBox.Show("文件格式错误");
                    return;
                }
                for (int i = 0; i < column; i++)
                {
                    gri[i, j] = Convert.ToInt32(data[i]);
                }
                j++;
            }
        }
        /// <summary>
        /// 将栅格信息转化为位图
        /// </summary>
        /// <returns>转化所得位图引用</returns>
        public Bitmap ToBitmap() ///mark
        {
            //以下部分生成随机颜色
            System.Drawing.Color[] colors = new System.Drawing.Color[21];//构建颜色列表
            System.Random r = new Random(System.DateTime.Now.Second);
            System.Random g = new Random(System.DateTime.Now.Minute);
            System.Random b = new Random(System.DateTime.Now.Hour);
            colors[0] = System.Drawing.Color.Transparent; //保证宇宙多边形（以外）为透明
            for (int i = 1; i < colors.Count(); i++)//生成随机颜色
            {
                colors[i] = System.Drawing.Color.FromArgb(r.Next(256), g.Next(256), b.Next(256));
            }
            
            //创建位图
            bitmap = new System.Drawing.Bitmap(column, row);
           // bitmap.SetResolution(1, 1);

            //由栅格数据填充位图
            for (int i = 0; i < column * row; i++)
            {
                if (gri[i % column,row - i / column - 1] < 0)
                {
                    bitmap.SetPixel(i % column, row - i / column - 1, colors[20]);
                    continue;
                }
                bitmap.SetPixel(i % column, row - i / column - 1, colors[gri[i % column,row - i / column - 1]% 20]);
            }
            return bitmap;
        }
        /// <summary>
        /// 将栅格数据写入文件
        /// </summary>
        /// <param name="sw">写入文件流</param>
        public void Save(StreamWriter sw)
        {
            
            string temp = "";
            temp = row.ToString() + " " + column.ToString();// pixel.ToString() + "\n";
            sw.WriteLine(temp);
            for (int i = 0; i < row; i++)
            {
                temp = "";
                for (int j = 0; j < column; j++)
                    temp += (gri[j, i].ToString() + " ");
                sw.WriteLine(temp);
            }
          
        }
    }
}
