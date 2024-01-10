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
        string cardNumStx;
        string cardNumEtx;
        bool cardNumReading = false;
        const string STX = "02";
        const string ETX = "03";
        const string ENV_CARD_TOKEN_ID  = "99BF0C1100";
        const string ENV_CARD_TOKEN_1ST = "023D010008";
        const string ENV_CARD_TOKEN_2ND = "023E010008";
        int readingCnt;
        string EnvToken;
        string[] spReads = new string[2];
        string spReadsDebug;


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
            //recvSize = 30;
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
                this.spReadsDebug += text.Length.ToString() + " ";
            }

            if (this.richRecived.InvokeRequired)
            {
                this.Invoke(new myRichReceivedCallback(richReceivedShow), new object[] {
                    recvStr
                });
                Console.WriteLine("invoke recvStr complete!");
            }
        }


        private void richReceivedShow(string text)
        {

            this.richRecived.Text += text;
            this.tbReadSize.Text += text.Length.ToString() + " ";
            this.tbSpReadSize.Text = this.spReadsDebug;
            int pos1 = -1, pos2 = -1;

            string parsingStx = text.Substring(0, 2);
            
            //-- 시작 reading
            if (parsingStx == STX && cardNumLen == 0 && cardNumReading == false)
            {
                cardReadInfoReset();
                this.cardNumStx = text.Substring(0, 2);
                this.cardNumReading = true;
                this.readingCnt = 0;
            }
            
            this.cardNum += text;
            this.cardNumLen += text.Length;

            string parseingEtx = text.Substring(text.Length - 2, 2);

            
            //-- 종료 reading
            if (parseingEtx == ETX)
            {
                pos1 = this.cardNum.IndexOf(ENV_CARD_TOKEN_1ST, StringComparison.OrdinalIgnoreCase);
                pos2 = this.cardNum.IndexOf(ENV_CARD_TOKEN_2ND, StringComparison.OrdinalIgnoreCase);

                if (this.cardNumLen == 30)
                {
                    if (pos2 == 0)
                    {
                        //cardReadInfoInit();
                        this.richRecived.Text += Environment.NewLine;

                        this.cardNumReading = false;
                        this.readingCnt = 1;
                        this.spReads[this.readingCnt] = this.cardNum;
                        //}
                        this.spReads[this.readingCnt] = this.cardNum;

                        lbStatus.Text = string.Format("{0}번째 reading", this.readingCnt + 1);

                        cardReadInfoReset();                        
                    }

                    if (pos1 == 0) { 
                        this.richRecived.Text += Environment.NewLine;
                        //this.richRecived.Text += "\r\n";
                        this.cardNumEtx = parseingEtx;

                        this.readingCnt = 0;
                        this.spReads[this.readingCnt] = this.cardNum;
                        setCardNum16(this.spReads[readingCnt].Substring(10, 16));

                        lbStatus.Text = string.Format("{0}번째 reading", this.readingCnt + 1);

                        cardReadInfoReset();

                    }
                }
            }
        }


        private void setCardNum16(string cardNum16)
        {
            if (this.cardNumLen >= 30)
            {
                this.textBoxCardNum16.Text = cardNum16;
                
            }
        }

        private void cardReadInfoInit()
        {
            this.textBoxCardNum16.Text = "";
            this.richRecived.Text = "";
            this.tbReadSize.Text = "";
            this.tbSpReadSize.Text = "";
            cardReadInfoReset();
        }

        private void cardReadInfoReset()
        {
            this.cardNumLen = 0;
            this.cardNum = "";
            //this.cardNumStx = "";
            //this.cardNumEtx = "";
            this.cardNumReading = false;
            this.spReadsDebug = "";
            this.readingCnt = 0;
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

        private void btInit_Click(object sender, EventArgs e)
        {
            this.textBoxCardNum16.Text = "";
            this.richRecived.Text = "";
            this.tbReadSize.Text = "";
            this.tbSpReadSize.Text = "";
            cardReadInfoReset();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}