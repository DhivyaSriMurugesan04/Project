using DAL_Reference.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using System.Threading.Tasks;


namespace DAL_Reference.Repository
{
    public class LoggerManager : ILoggerManager
    {
        private static NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        public void LogDebug(string message) => logger.Error(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInfo(string message) => logger.Error(message);
        public void LogWarn(string message) => logger.Error(message);
    }
}
