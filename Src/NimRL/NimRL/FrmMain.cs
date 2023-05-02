using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NimRL
{
    public partial class FrmMain : Form
    {
        // Ctor
        public FrmMain()
        {
            InitializeComponent();
        }


        // Methods
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Lime;
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
