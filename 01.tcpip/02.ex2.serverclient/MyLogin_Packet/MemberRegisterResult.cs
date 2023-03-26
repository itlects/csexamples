using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogin_Packet
{
    [Serializable]
    public class MemberRegisterResult : Packet
    {
        public bool result { get; set; }
        public string reason { get; set; }
    }
}
