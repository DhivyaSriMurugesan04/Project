using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace DAL_Reference.Interfaces
{
    public interface ILoggerManager
    {
        public void LogInfo(string message);
        public void LogWarn(string message);
        public void LogDebug(string message);
        public void LogError(string message);
    }
}