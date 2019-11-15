using System;
using System.Collections.Generic;

namespace ServerLogLibrary
{
    public interface ILogFileManager
    {
       IEnumerable<Log> GetLogs();
    }
}
