using ProjectManagement.ProjectLogger.Interface;
using System;
using NLog;

namespace ProjectManagement.ProjectLogger
{
    public class MainLogger : IProjectLogger
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static MainLogger() { }

        public void Log(MessageLogLevel level, string message) => 
            logger.Log(ToNLogLevel(level), message);

        public void Log(MessageLogLevel level, string message, params object[] args) =>
            logger.Log(ToNLogLevel(level), message, args);

        public void Log<T>(MessageLogLevel level, string message, T arg) =>
            logger.Log(ToNLogLevel(level), message, arg);

        public void Log<T1, T2>(MessageLogLevel level, string message, T1 arg1, T2 arg2) =>
            logger.Log(ToNLogLevel(level), message, arg1, arg2);

        public void Log(MessageLogLevel level, IFormatProvider formatProvider, string message, params object[] args) =>
            logger.Log(ToNLogLevel(level), formatProvider, message, args);

        public void Log<T>(MessageLogLevel level, IFormatProvider formatProvider, string message, T arg) =>
            logger.Log(ToNLogLevel(level), formatProvider, message, arg);

        public void Log<T1, T2>(MessageLogLevel level, IFormatProvider formatProvider, string message, T1 arg1, T2 arg2) =>
            logger.Log(ToNLogLevel(level), formatProvider, message, arg1, arg2);

        private LogLevel ToNLogLevel(MessageLogLevel logLevel)
        {
            switch (logLevel)
            {
                case MessageLogLevel.Trace:
                    return NLog.LogLevel.Trace;
                case MessageLogLevel.Debug:
                    return NLog.LogLevel.Debug;
                case MessageLogLevel.Info:
                    return NLog.LogLevel.Info;
                case MessageLogLevel.Warn:
                    return NLog.LogLevel.Warn;
                case MessageLogLevel.Error:
                    return NLog.LogLevel.Error;
                case MessageLogLevel.Fatal:
                    return NLog.LogLevel.Fatal;
                default:
                    throw new ArgumentException(nameof(logLevel));
            }
        }
    }
}
