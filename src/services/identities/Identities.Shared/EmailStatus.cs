using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identities.Shared
{
#nullable disable
    public class EmailStatus
    {
        public string Receiver { get; set; }
        public int Captcha { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
