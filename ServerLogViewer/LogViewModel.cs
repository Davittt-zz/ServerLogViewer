using ServerLogLibrary;
using System.Collections.Generic;

namespace ServerLogViewer
{
    internal class LogViewModel : IServerViewModel
    {
        private static LogFileManager _logFileManager { get; set; }

        public LogViewModel()
        {
        }

        public void LoadLogFile(string filename)
        {
            _logFileManager = new LogFileManager(filename);
        }

        public IEnumerable<IServerDataItem> GetViewItems()
        {
            foreach (var item in _logFileManager.GetLogs())
            {
                yield return item;
            }
        }
              
    }
}
