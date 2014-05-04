using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace gis
{
   
    ///想了想显示部分还是应该放入窗体类以减小类与类之间的耦合，故注释掉以下函数
    //partial class E00
    //{
    //    public bool display(Graphics draw)
    //    {

    //        Pen pen = new Pen(Color.Black, 1);
    //        draw.DrawLine(pen, 1, 1, 2, 3);
    //        for (int i = 0; i < ARCList.Count; i++)
    //        {
    //            draw.DrawLines(pen, ARCList[i].pointlist);
    //        }

    //        return false;
    //    }
    //}
    //public partial class Grid
    //{
    //    public bool display(Graphics draw)
    //    {
    //        return false;
    //    }
    //}
}
