using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.Utilities.Log
{
    public class LogActionModel
    {
        public long SessionID { get; set; }
        public long FirstAccount { get; set; }
        public long SecondAccount { get; set; }
        public byte Action { get; set; }
        public string Cards { get; set; }
        public long Revenue { get; set; }
    }
}
