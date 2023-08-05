namespace WinFormsParamAppTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 f2;
        //Form2 f2 = new Form2();
        private void button1_Click(object sender, EventArgs e)
        {

            //f2 = new Form2(this);
            f2 = new Form2(this, "subÆû");
            //f2.Show(); //-- modaless
            this.Hide();
            f2.ShowDialog(); //-- modal
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String s1 = f2.textBox1.Text;
            MessageBox.Show(s1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = DataStore.shareFormData;
        }
    }
}