using System.IO.Ports;
using static System.Net.Mime.MediaTypeNames;

namespace NFCReader2
{
    public partial class Form1 : Form
    {
        string text;
        SerialPort sp;
        int[] baudRates = { 9600, 19200, 38400, 115200 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sp = new SerialPort();
            btOpen.Enabled = true;
            btClose.Enabled = false;

            cbPort.BeginUpdate();
            foreach (string port in SerialPort.GetPortNames())
            {
                cbPort.Items.Add(port);
            }
            cbPort.EndUpdate();
            cbPort.SelectedItem = "COM9";

            cbBaudRate.Enabled = true;
           
            cbBaudRate.BeginUpdate();
            foreach (int baudRate in baudRates)
            {
                cbBaudRate.Items.Add(baudRate);
            }
            cbBaudRate.EndUpdate();
            cbBaudRate.SelectedItem = baudRates[2];
            cbBaudRate.EndUpdate();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            try {
                if (sp != null) { 
                    sp = new SerialPort();
                    sp.DataReceived += new SerialDataReceivedEventHandler(sp1_datareceived);

                    sp.PortName = (string)cbPort.SelectedItem;
                    sp.BaudRate = baudRates[cbBaudRate.SelectedIndex];
                    sp.DataBits= (int)8;
                    sp.Parity = Parity.None;
                    sp.StopBits=StopBits.One;
                    sp.ReadTimeout = (int)500;
                    sp.WriteTimeout = (int)500;
                    //sp.RtsEnable = false;

                    sp.Open();
                            //sp.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                }

                if (sp.IsOpen)
                {
                    btOpen.Enabled = false;
                    btClose.Enabled = true;
                    MessageBox.Show("시리얼포트를 연결했습니다");
                }
                else
                {
                    btClose.Enabled = false;
                    btOpen.Enabled = true;

                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(spRCV));
        }
        private void spRCV(object sender, EventArgs e)
        {
            if (sp.BytesToRead > 0)
            {
                tbRead.Text = sp.ReadExisting();
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //textBox1.Text = serialPort1.ReadExisting();

            this.Invoke(new EventHandler(sprtRCV));
        }

        private void sprtRCV(object sender, EventArgs e)
        {
            if (sp.BytesToRead > 0)//데이터가 읽혀지면 출력
            {
                tbRead.Text = sp.ReadExisting();
            }
            Thread.Sleep(1000);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (sp != null)
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                    sp.Dispose();
                    sp = null;
                }
            }
            btOpen.Enabled = true;
            btClose.Enabled = false;
        }


        delegate void mySetTextbox1Callback(string text);
        private void sp1_datareceived(object sender, SerialDataReceivedEventArgs e)
        {
            //this.Invoke(new MethodInvoker(sp1_RCV));


            int recvSize = sp.BytesToRead;
            string recvStr = string.Empty;

            if (recvSize != 0)
            {
                byte[] buf = new byte[recvSize];

                sp.Read(buf, 0, recvSize);
                for (int i = 0; i < recvSize; i++)
                {
                    recvStr += " " + buf[i].ToString("X2");

                }
                //-- MessageBox.Show(recvStr);
                text = recvStr;
            }
            //Thread thread = new Thread(new ThreadStart(textBox1Show));
            //thread.Start();

            if (this.tbRead.InvokeRequired)
            {
                this.Invoke(new mySetTextbox1Callback(textBox1Show), new object[]{
                    recvStr
                });
                //-- Thread.Sleep(2000);
            }
        }

        private void textBox1Show(string text)
        {
            this.tbRead.Text += text;
        }
    }
}