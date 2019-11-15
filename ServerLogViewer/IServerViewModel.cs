using ServerLogLibrary;
using System.Collections.Generic;

namespace ServerLogViewer
{
    internal interface IServerViewModel
    {
        IEnumerable<IServerDataItem> GetViewItems();

        void LoadLogFile(string filename);
    }
}
