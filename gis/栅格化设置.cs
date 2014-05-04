using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gis
{
    public partial class 栅格化设置 : Form
    {
        public 栅格化设置()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.grid = new Grid(Form1.e00 , Convert.ToInt32(numericUpDown1.Value));
            Dispose();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

    

     

    }
}
