using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3FormsLoadDialog
{
    public partial class Form2 : Form
    {
        Form1 f1 = null;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.f1 = form1;
            this.FormClosing += new FormClosingEventHandler(Form2Closing);
        }
        private void Form2Closing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            f1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
            this.button2.Enabled = false;
            this.button3.Enabled = true;
        }
    }
}
