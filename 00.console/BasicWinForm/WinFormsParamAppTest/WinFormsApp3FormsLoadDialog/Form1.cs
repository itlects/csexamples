namespace WinFormsApp3FormsLoadDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        Form2 f2;
        private void button2_Click(object sender, EventArgs e)
        {
            f2 = new Form2(this);
            this.Hide();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = true;
            this.button3.Enabled = true;
        }
    }
}