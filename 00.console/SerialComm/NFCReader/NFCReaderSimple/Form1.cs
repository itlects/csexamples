using System.IO.Ports;

namespace NFCReaderSimple
{
    public partial class Form1 : Form
    {
        int n1 = 0;
        string text;
        SerialPort sp1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sp1= new SerialPort();

            sp1.PortName = "COM9";
            sp1.BaudRate = (int)38400;
            sp1.DataBits= 8;
            sp1.Parity = Parity.None;
            sp1.StopBits = StopBits.One;
            sp1.Open();
            sp1.DataReceived += new SerialDataReceivedEventHandler(sp1_datareceived);

        }

        delegate void mySetTextbox1Callback(string text);
        private void sp1_datareceived(object sender, SerialDataReceivedEventArgs e)
        {
            //this.Invoke(new MethodInvoker(sp1_RCV));


            int recvSize = sp1.BytesToRead;
            string recvStr = string.Empty;

            if (recvSize != 0)
            {
                byte[] buf = new byte[recvSize];

                sp1.Read(buf, 0, recvSize);
                for(int i=0; i < recvSize; i++)
                {
                    recvStr += buf[i].ToString("X2");
                    recvStr += " ";
                }
                //--- MessageBox.Show(recvStr);
                text = recvStr;
            }
            //Thread thread = new Thread(new ThreadStart(textBox1Show));
            //thread.Start();

            if (this.textBox1.InvokeRequired)
            {
                this.Invoke(new mySetTextbox1Callback(textBox1Show), new object[]{
                    recvStr
                });
                Thread.Sleep(1000);
            }
        }

        private void textBox1Show(string text)
        {
            this.textBox1.Text += "["+(n1++)+"]";
            this.textBox1.Text += text;
        }
    }
}