using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace gis
{
    /// <summary>
    /// 弧段类 每个对象代表一组点表示的弧线
    /// </summary>
    public class ARC
    {
        /// <summary>
        /// 弧段号
        /// </summary>
        int arcNo;
        /// <summary>
        /// 弧段ID
        /// </summary>
        int id;
        /// <summary>
        /// 起始节点号
        /// </summary>
        int beginPointNo;
        /// <summary>
        /// 终止节点号
        /// </summary>
        int endPointNo;
        /// <summary>
        /// 左多边形号
        /// </summary>
        public int leftPalNo;
        /// <summary>
        /// 右多边形号
        /// </summary>
        public int rightPalNo;
        /// <summary>
        /// 点数
        /// </summary>
        public int pointNum;
        /// <summary>
        /// 弧段节点数组
        /// </summary>
        public PointF[] pointlist;
        /// <summary>
        /// 用于作图的节点数组
        /// </summary>
        public PointF[] pointlist_draw;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="head">已经读入的弧段头信息</param>
        /// <param name="input">剩余文件流</param>
        public ARC(string head,StreamReader input)
        {
            //将弧段头信息分割
            string[] data;
            char[] splitchar = new char[] { ' ' };
            data = head.Split(splitchar,StringSplitOptions.RemoveEmptyEntries);
            
            //将弧段头信息转换成正确的格式并存储
            arcNo = Convert.ToInt32(data[0]);
            id = Convert.ToInt32(data[1]);
            beginPointNo = Convert.ToInt32(data[2]);
            endPointNo = Convert.ToInt32(data[3]);
            leftPalNo = Convert.ToInt32(data[4]);
            rightPalNo = Convert.ToInt32(data[5]);
            pointNum = Convert.ToInt32(data[6]);
            pointlist = new PointF[pointNum];
            pointlist_draw = new PointF[pointNum];
            //存储弧段节点信息，考虑到文件一行有两个点的数据，用取模运算处理
            for (int i = 0; i < pointNum; i++)
            {
                if(i%2 == 0)
                    data = input.ReadLine().Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
                pointlist[i] = new PointF(Convert.ToSingle(data[(2 * i) % 4]), Convert.ToSingle(data[(2 * i + 1) % 4]));
            }
        }
    }
    /// <summary>
    /// 多边形中的弧段
    /// 每一对象代表多边形中的一条弧段，为简化PAL类而设计
    /// </summary>
    struct arcInPal
    {
        /// <summary>
        /// 弧段号
        /// </summary>
        public int arcNo;
        /// <summary>
        /// 终止节点号
        /// </summary>
        public int endPointNo;
        /// <summary>
        /// 另一多边形号
        /// </summary>
        public int anotherPal;
    }
    /// <summary>
    /// 多边形类，每一实例代表存储的一个多边形
    /// </summary>
    public class PAL
    {
        /// <summary>
        /// 弧段数
        /// </summary>
        int arcNum;
        /// <summary>
        /// x坐标最小值
        /// </summary>
        public float xMin;
        /// <summary>
        /// y坐标最小值
        /// </summary>
        float yMin;
        /// <summary>
        /// x坐标最大值
        /// </summary>
        float xMax;
        /// <summary>
        /// y坐标最大值
        /// </summary>
        public float yMax;
        /// <summary>
        /// 多边形中的弧段数组
        /// </summary>
        arcInPal[] arclist;
        /// <summary>
        /// 多边形类构造函数
        /// </summary>
        /// <param name="head">已读入的多边形头信息</param>
        /// <param name="input">剩余文件流</param>
        public PAL(string head,StreamReader input)
        {
            //切分头信息
            string[] data;
            char[] splitchar = new char[] { ' ' };
            data = head.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
            
            //转化头信息格式并储存
            arcNum = Convert.ToInt32(data[0]);
            xMin = Convert.ToSingle(data[1]);
            yMin = Convert.ToSingle(data[2]);
            xMax = Convert.ToSingle(data[3]);
            yMax = Convert.ToSingle(data[4]);
            arclist = new arcInPal[arcNum];

            //读入多边形中的弧段信息
            for (int i = 0; i < arcNum; i++)
            {
                if (i % 2 == 0)
                    data = input.ReadLine().Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
                arclist[i].arcNo = Convert.ToInt32(data[i * 3 % 6]);
                arclist[i].endPointNo = Convert.ToInt32(data[(i * 3 +1)% 6]);
                arclist[i].anotherPal = Convert.ToInt32(data[(i * 3 + 2) % 6]);
            }
        }


        public float width()
        {
            return xMax - xMin;
        }
        public float height()
        {
            return yMax - yMin;
        }
    }
    /// <summary>
    /// E00类 存储整个e00文件信息
    /// </summary>
    public partial class E00
    {
        /// <summary>
        /// 使用C#自带List类型存储所有弧段信息
        /// </summary>
        public List<ARC> ARCList = new List<ARC>();
        ///// <summary>
        ///// 生成用于作图的弧段List
        ///// </summary>
        //public List<ARC> ARCList_draw = new List<ARC>();
        /// <summary>
        /// 使用C#自带List类型存储所有多边形信息
        /// </summary>
        public List<PAL> PALList = new List<PAL>();
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="input">读入文件流</param>
        public E00(StreamReader input)
        {
            string temp;
            string[] data;
            char[] splitchar = new char[] {' '};

            //一行一行读取文件
            while ((temp = input.ReadLine()) != null)
            {
                data = temp.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
                
                //读取掉空行
                if (data.Count() == 0)
                    continue;

                //假如为弧段数据，调用弧段构造函数，加入弧段List中
                if (data[0].Equals("ARC"))
                    while ((temp = input.ReadLine()) != null && !(temp.Split(splitchar, StringSplitOptions.RemoveEmptyEntries))[0].Equals("-1"))
                        ARCList.Add(new ARC(temp, input));

                //假如为多边形数据，调用多边形构造函数，加入多边形List中
                if (data[0].Equals("PAL"))
                    while ((temp = input.ReadLine()) != null && !(temp.Split(splitchar, StringSplitOptions.RemoveEmptyEntries))[0].Equals("-1"))
                        PALList.Add(new PAL(temp, input));
            }
            for (int i = 0; i < ARCList.Count; i++)
            {
                for (int j = 0; j < ARCList[i].pointNum; j++)
                {
                    ARCList[i].pointlist_draw[j] = new PointF(ARCList[i].pointlist[j].X - PALList[0].xMin, PALList[0].yMax - ARCList[i].pointlist[j].Y);
                }
            }
        }
        
    }

}
