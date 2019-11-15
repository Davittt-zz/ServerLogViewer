using System;

namespace ServerLogLibrary
{
    public  interface IServerDataItem
    {
        public DateTime Time { get; set; }
        public string Delta { get; set; }
        public string EventName { get; set; }
        public string FromTo { get; set; }
        public string Payload { get; set; }
    }
}
