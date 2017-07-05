using System;
using System.ComponentModel;

namespace ProjectManagement.ProjectLogger.Interface
{
    public interface IProjectLogger
    {
        void Log(MessageLogLevel level, [Localizable(false)] string message);

        void Log(MessageLogLevel level, [Localizable(false)] string message, params object[] args);

        void Log<T>(MessageLogLevel level, [Localizable(false)] string message, T arg);

        void Log<T1, T2>(MessageLogLevel level, [Localizable(false)] string message, T1 arg1, T2 arg2);

        void Log(MessageLogLevel level, IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);

        void Log<T>(MessageLogLevel level, IFormatProvider formatProvider, [Localizable(false)] string message, T arg);

        void Log<T1, T2>(MessageLogLevel level, IFormatProvider formatProvider, [Localizable(false)] string message, T1 arg1, T2 arg2);
    }
}
