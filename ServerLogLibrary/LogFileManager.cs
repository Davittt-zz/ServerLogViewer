using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerLogLibrary
{
    public class LogFileManager : ILogFileManager
    {
        private string _fileName { get; set; }

        public LogFileManager(string filename)
        {
            this._fileName = filename;
        }

        public IEnumerable<Log> GetLogs()
        {
            List<Log> logIndex = new List<Log> {
                new Log { Time = DateTime.Now, EventName = "eventname", Delta = "delta", FromTo = "a", Payload = "payload" },
                new Log { Time = DateTime.Now.AddDays(1), EventName = "eventname", Delta = "delta", FromTo = "b", Payload = "payloadpayloadpayloadpayloadpayloadpayll" },
                new Log { Time = DateTime.Now, EventName = "eventname", Delta = "delta", FromTo = "c", Payload = "payload" },
                new Log { Time = DateTime.Now, EventName = "eventname", Delta = "delta", FromTo = "d", Payload = "oadpayloadpayloadpayloadpayloadpayloadpayloadpayloadpayloadpayloadpayloadpayloadpayl" },
                new Log { Time = DateTime.Now, EventName = "eventname", Delta = "delta", FromTo = "e", Payload = "payload" },
                new Log { Time = DateTime.Now, EventName = "eventname", Delta = "delta", FromTo = "f", Payload = "payload" },
                new Log { Time = DateTime.Now, EventName = "eventname", Delta = "delta", FromTo = "g", Payload = "payload" }
            };

            foreach (Log log in logIndex)
            {
                yield return log;
            }
        }
    }
}
