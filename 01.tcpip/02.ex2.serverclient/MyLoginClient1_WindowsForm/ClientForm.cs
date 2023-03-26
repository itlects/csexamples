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

using MyLogin_Packet;


namespace MyLoginClient1_WindowsForm
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] buffer = new byte[1024 * 4];

                // 1. connect to server
                TcpClient client = new TcpClient("192.168.0.10", 7778);
                NetworkStream stream = client.GetStream();

                // 2. send the packet
                Login login = new Login();
                login.packet_Type = (int)PacketType.Login;
                login.id_str = textBox1.Text.Trim();
                login.pw_str = textBox2.Text.Trim();

                Packet.Serialize(login).CopyTo(buffer, 0);

                stream.Write(buffer, 0, buffer.Length);

                // 3. receive the packet
                Array.Clear(buffer, 0, buffer.Length);

                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                LoginResult loginResult = (LoginResult)Packet.Deserialize(buffer);

                if (loginResult.result)
                {
                    MessageBox.Show(loginResult.reason, "클라이언트 확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(loginResult.reason, "클라이언트 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // 4. close the socket
                stream.Close();
                client.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            { 
                byte[] buffer = new byte[1024 * 4];

                // 1. connect to server
                TcpClient client = new TcpClient("192.168.0.10", 7778);
                NetworkStream stream = client.GetStream();

                // 2. send the packet
                MemberRegister memberRegister = new MemberRegister();
                memberRegister.packet_Type = (int)PacketType.Member_REGISTER;
                memberRegister.id_str = textBox3.Text.Trim();
                memberRegister.pw_str = textBox4.Text.Trim();
                memberRegister.nickname_str = textBox5.Text.Trim();

                Packet.Serialize(memberRegister).CopyTo(buffer, 0);

                stream.Write(buffer, 0, buffer.Length);

                // 3. receive the packet
                Array.Clear(buffer, 0, buffer.Length);

                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                MemberRegisterResult mrResult = (MemberRegisterResult)Packet.Deserialize(buffer);

                if (mrResult.result)
                {
                    MessageBox.Show(mrResult.reason, "클라이언트 확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(mrResult.reason, "클라이언트 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // 4. close the socket
                stream.Close();
                client.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
