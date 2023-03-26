using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

using MyLogin_Packet;

namespace MyLoginServer1_WindowsForm
{
    public class UserSocket
    {
        public NetworkStream server_netStream = null;

        public bool server_isClientOnline = false;
        public byte[] sendBuffer = new byte[1024 * 4];
        public byte[] readBuffer = new byte[1024 * 4];

        public string UserName = string.Empty;

        public Login server_LoginClass = null;
        public Socket client = null;
    }
}
