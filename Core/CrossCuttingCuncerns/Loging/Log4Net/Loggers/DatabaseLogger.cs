using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingCuncerns.Loging.Log4Net.Loggers
{
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger() : base("DatabaseLogger")
        {
        }
    }
}
