using System.IO.Ports;

namespace SerialTest
{
    public partial class Form1 : Form
    {
        SerialPort sPort;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;

            cboPortName.BeginUpdate();
            foreach (string comport in SerialPort.GetPortNames())
            {
                cboPortName.Items.Add(comport);
            }
            cboPortName.EndUpdate();

            cboPortName.SelectedItem = "COM14";
            txtBaudRate.Text = "38400";

            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == sPort)
                {
                    sPort = new SerialPort();
                    sPort.DataReceived += new SerialDataReceivedEventHandler(sPort_DataReceived);

                    sPort.PortName = cboPortName.SelectedItem.ToString();
                    sPort.BaudRate = Convert.ToInt32(txtBaudRate.Text);
                    sPort.DataBits = (int)8;
                    sPort.Parity = Parity.None;
                    sPort.StopBits = StopBits.One;
                    sPort.ReadTimeout = (int)500;
                    sPort.WriteTimeout = (int)500;
                    sPort.Open();
                }

                if (sPort.IsOpen)
                {
                    btnOpen.Enabled = false;
                    btnClose.Enabled = true;

                    MessageBox.Show("시리얼 포트를 연결했습니다.");
                }
                else
                {
                    btnOpen.Enabled = true;
                    btnClose.Enabled = false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] byteSendData = new byte[200];
            int iSendCount = 0;
            try
            {
                if (true == chkSndHexa.Checked)
                {
                    foreach (string s in txtSend.Text.Split(' '))
                    {
                        if (s != null && s != "")
                        {
                            byteSendData[iSendCount++] = Convert.ToByte(s, 16);
                        }
                    }
                    sPort.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    sPort.Write(txtSend.Text);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void sPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int intRecSize = sPort.BytesToRead;
            string strRecData;

            if (intRecSize != 0)
            {
                strRecData = "";
                byte[] buff = new byte[intRecSize];

                sPort.Read(buff, 0, intRecSize);
                for (int iTemp = 0; iTemp < intRecSize; iTemp++)
                {
                    if (chkRecHexa.Checked)
                    { strRecData += buff[iTemp].ToString("X2") + " "; }
                    else
                    { strRecData += Convert.ToChar(buff[iTemp]); }
                }
                txtRec.Text += strRecData;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (null != sPort)
            {
                if (sPort.IsOpen)
                {
                    sPort.Close();
                    sPort.Dispose();
                    sPort = null;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (null != sPort)
            {
                if (sPort.IsOpen)
                {
                    sPort.Close();
                    sPort.Dispose();
                    sPort = null;
                }
            }

            btnOpen.Enabled = true;
            btnClose.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRec.Clear();
        }
    }
}