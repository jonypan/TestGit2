using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.Utilities.Log
{
    public class LogBeginSession
    {
        public byte GameID { get; set; }
        public long SessionID { get; set; }
        public List<LogPlayerData> Players { get; set; }
        public List<LogPlayerData> BeginData { get; set; }
    }

    public class LogEndSession
    {
        public long SessionID { get; set; }
        public List<LogActionModel> Actions { get; set; }
        public List<LogPlayerData> EndData { get; set; }
    }

    public class LogPlayerData
    {
        public long AccountID { get; set; }
        public string Additional { get; set; }
    }
}
