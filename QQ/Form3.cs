using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQ
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//设置本窗体
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            /*backPicture.SendToBack();
            chooseBackground.Parent = backPicture;
            paff.Parent = chooseBackground;*/
            Form1 f1 = new Form1();
           

        }
    }
}
