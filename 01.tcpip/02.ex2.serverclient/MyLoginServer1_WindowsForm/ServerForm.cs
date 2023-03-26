using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

using MyLogin_Packet;



namespace MyLoginServer1_WindowsForm
{
    public partial class ServerForm : Form
    {
        TcpListener listener = null;
        Random random = new Random();
        private void setLog(string msg)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                textBox1.AppendText(msg + "\n");
            });
        }
        
        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            Thread t_handler = new Thread(StartSocket);
            t_handler.IsBackground = true;
            t_handler.Start();
        }

        private void StartSocket()
        {
            listener = new TcpListener(IPAddress.Any, 7778);
            listener.Start();

            try
            {
                // Buffer for reading data
                byte[] buffer = new byte[1024 * 4];
                string data = string.Empty;

                while (true)
                {
                    setLog("Waiting for connection...");
                    setLog("");

                    TcpClient client = listener.AcceptTcpClient();
                    setLog("Connected!");

                    data = string.Empty;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int bytesRead = 0;
                    // Loop to receive all the data sent by the client
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        AnalyzePacket(stream, buffer);
                    }

                    // Shutdown and end connection
                    stream.Close();
                    client.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnalyzePacket(NetworkStream stream, byte[] buffer)
        {
            Packet packet = (Packet)Packet.Deserialize(buffer);

            if (packet == null)
                return;

            switch ((int)packet.packet_Type)
            {
                case (int)PacketType.Login:
                    {
                        // 받은 패킷을 Login class 로 deserialize 시킴
                        Login login = (Login)Packet.Deserialize(buffer);

                        setLog(string.Format("ID : {0}, PWD : {1}", login.id_str, login.pw_str));

                        // 전송할 패킷을 LoginResult class 로 serialize 시킴
                        LoginResult loginResult = new LoginResult();
                        loginResult.packet_Type = (int)PacketType.Login_RESULT;
                        if (random.Next(1, 100) % 2 == 0)    // 짝수라면.... 로그인 성공 
                        {
                            loginResult.result = true;
                            loginResult.reason = "정상적으로 로그인이 되었습니다.";
                        }
                        else                                // 홀수라면.... 로그인 실패
                        {
                            loginResult.result = false;
                            loginResult.reason = "아이디와 비밀번호를 확인 하시기 바랍니다.";
                        }

                        Array.Clear(buffer, 0, buffer.Length);
                        Packet.Serialize(loginResult).CopyTo(buffer, 0);
                        stream.Write(buffer, 0, buffer.Length);

                        setLog("");
                    }
                    break;
                case (int)PacketType.Member_REGISTER:
                    {
                        // 받은 패킷을 MemberRegister class 로 deserialize 시킴
                        MemberRegister memberRegister = (MemberRegister)Packet.Deserialize(buffer);

                        setLog(string.Format("ID : {0}, PWD : {1}, Nickname : {2}", 
                                                memberRegister.id_str, memberRegister.pw_str, memberRegister.nickname_str));

                        // 전송할 패킷을 LoginResult class 로 serialize 시킴
                        MemberRegisterResult mrResult = new MemberRegisterResult();
                        mrResult.packet_Type = (int)PacketType.Member_REGISTER_RESULT;
                        if (random.Next(1, 100) % 2 == 0)    // 짝수라면.... 로그인 성공 
                        {
                            mrResult.result = true;
                            mrResult.reason = "회원 가입이 정상적으로 되었습니다.";
                        }
                        else                                // 홀수라면.... 로그인 실패
                        {
                            mrResult.result = false;
                            mrResult.reason = "회원가입 오류입니다.";
                        }

                        Array.Clear(buffer, 0, buffer.Length);
                        Packet.Serialize(mrResult).CopyTo(buffer, 0);
                        stream.Write(buffer, 0, buffer.Length);

                        setLog("");
                    }
                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listener != null)
            {
                listener.Stop();
            }
            this.Close();
        }
    }
}
