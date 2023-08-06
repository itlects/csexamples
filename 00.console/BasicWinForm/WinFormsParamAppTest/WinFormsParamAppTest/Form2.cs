using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsParamAppTest
{
    public partial class Form2 : Form
    {
        Form1 f1 = null;
        public Form2(Form1 form1, string v)
        {
            InitializeComponent();
            this.f1 = form1;
            this.Text = v;
            this.FormClosing += new FormClosingEventHandler(Form2Closing);
        }

        private void Form2Closing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            f1.Show();
        }

        private bool xClicked = true;

        private void button1_Click(object sender, EventArgs e)
        {
            xClicked = false;
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //f1 = new Form1();
            String s1 = textBox1.Text;
            if(s1!=null || s1.Length > 0)
            {
                f1.Text = s1;
            }
            else { 
                f1.Text = "abc";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataStore.shareFormData = this.textBox1.Text;
        }
    }
}
