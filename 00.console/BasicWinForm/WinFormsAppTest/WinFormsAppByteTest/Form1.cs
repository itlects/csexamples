namespace WinFormsAppEventTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("program init...");
            checkBox1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = "button1 click!...";
            Console.WriteLine(msg);
            var line = richTextBox1.Lines.Count();
            if (line > 0)
            {
                richTextBox1.AppendText("\r\n");
            }
            richTextBox1.AppendText(msg);
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox1 = sender as CheckBox;
            string msg = null;
            var line = richTextBox1.Lines.Count();
            if (line > 0)
            {
                richTextBox1.AppendText("\r\n");
            }
            if (checkBox1.Checked == true)
            {
                msg = "checkbBox1 check true...";
                Console.WriteLine(msg);
                richTextBox1.AppendText(msg);
            }
            else
            {
                msg = "checkBox1 check false...";
                Console.WriteLine(msg);
                richTextBox1.AppendText(msg);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg = textBox1.Text;
            if(msg.Length > 0 && msg!=null) {
                var line = richTextBox1.Lines.Count();
                if (line > 0)
                {
                    richTextBox1.AppendText("\r\n");
                }
                richTextBox1.AppendText(msg);
                textBox1.Clear();
            }
        }

        /*
         richTextBox1���� ���콺Ŭ�� ������ ������ ��ü�ٿ� �������� ����ǥ���ϰ�
         richTextBox2�� ���õ� text�� ����ϰ� ��
         */
        private void richTextBox1_Click(object sender, EventArgs e)
        {
            var richTextBox = sender as RichTextBox;
            int firstcharIndex = richTextBox1.GetFirstCharIndexOfCurrentLine();
            int currLine = richTextBox1.GetLineFromCharIndex(firstcharIndex);
           
            string text = richTextBox1.Lines[currLine];
            richTextBox1.Select(firstcharIndex, text.Length);
            
            if (richTextBox != null) { 
                text = richTextBox.SelectedText;
            }
            var line = richTextBox2.Lines.Count();
            string msg = text;//"hello!";
            if (line > 0)
            {
                //richTextBox2.AppendText("\r\n");
                richTextBox2.Clear();
            }
            richTextBox2.AppendText(msg);
        }
    }
}