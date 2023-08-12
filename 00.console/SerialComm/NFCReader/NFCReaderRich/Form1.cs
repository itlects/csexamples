using System.IO.Ports;
using static System.Net.Mime.MediaTypeNames;

namespace NFCReaderRich
{
    public partial class Form1 : Form
    {
        string text;
        SerialPort sp;
        int[] baudRates = { 9600, 19200, 38400, 115200 };
        int[] cardNumMaxLen = { 30, 60 };
        int cardNumLen;
        string cardNum;

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

            cbBaudrate.Enabled = true;
            cbBaudrate.BeginUpdate();
            foreach (int baudRate in baudRates)
            {
                cbBaudrate.Items.Add(baudRate);
            }
            cbBaudrate.EndUpdate();
            cbBaudrate.SelectedItem = baudRates[2];
            cbBaudrate.EndUpdate();

            //CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!sp.IsOpen)
                {
                    sp = new SerialPort();
                    sp.DataReceived += new SerialDataReceivedEventHandler(sp_dataReceived);
                    sp.PortName = (string)cbPort.SelectedItem;
                    sp.BaudRate = baudRates[cbBaudrate.SelectedIndex];
                    sp.Parity = Parity.None;
                    sp.StopBits = StopBits.One;
                    sp.DataBits = 8;
                    sp.ReadTimeout = (int)500;
                    sp.WriteTimeout = (int)500;
                    sp.Open();

                    lbStatus.Text = "포트가 열렸습니다.";
                    cbPort.Enabled = false;
                }
                else
                {
                    lbStatus.Text = "포트가 이미 열려 있습니다.";
                }

                if (sp.IsOpen)
                {
                    btOpen.Enabled = false;
                    btClose.Enabled = true;
                    lbStatus.Text = "시리얼포트를 연결했습니다.";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        delegate void myRichReceivedCallback(string text);
        private void sp_dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int recvSize = sp.BytesToRead;
            string recvStr = string.Empty;

            if (recvSize != 0)
            {
                byte[] buf = new byte[recvSize];
                sp.Read(buf, 0, recvSize);
                for (int i = 0; i < recvSize; i++)
                {
                    recvStr += buf[i].ToString("X2");
                }
                text = recvStr;
            }

            if (this.richRecived.InvokeRequired)
            {
                this.Invoke(new myRichReceivedCallback(richReceivedShow), new object[] {
                    recvStr
                });
            }
        }

        private void richReceivedShow(string text)
        {
            
            this.richRecived.Text += text;
            this.tbReadSize.Text += text.Length.ToString() + " ";

            this.cardNum += text; 
            this.cardNumLen += text.Length;
            string s1 = this.cardNum;
            int pos = s1.IndexOf("9A03", StringComparison.OrdinalIgnoreCase);
            //string token = s1.Substring(pos, 4);
            if (cardNumLen == 30 && pos!=26)
            {
                this.richRecived.Text += Environment.NewLine;
                //this.richRecived.Text += "\r\n";
                cardNumLen = 0;
                cardNum = "";
            }
            if (cardNumLen == 60 && pos == 26)
            {
                this.richRecived.Text += Environment.NewLine;
                //this.richRecived.Text += "\r\n";
                cardNumLen = 0;
                cardNum = "";
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                lbStatus.Text = "연결해제되었습니다.";
            }
            else
            {
                lbStatus.Text = "연결해제되었습니다.";
            }
            this.btClose.Enabled = false;
            this.btOpen.Enabled = true;
        }
    }
}