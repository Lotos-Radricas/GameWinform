using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWinform
{
    public partial class Form2 : Form
    {

        private Form1 form1;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Exit_Buttom_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            form1.Enabled = true;
            this.Close();
            form1.RestartGame();
        }
    }
}
