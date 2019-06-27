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
    public partial class resignSuccess : Form
    {
        public resignSuccess()
        {
            InitializeComponent();
        }

        private void ConforButton_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void ResignSuccess_Load(object sender, EventArgs e)
        {
            success.Parent = backGround;
            conforButton.Parent = backGround;
            clickButten.Parent = backGround;
        }
    }
}
