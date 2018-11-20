using System;
using NLog;


namespace Trader.Ancillary
{
    public class LogHolder
    {
        private static EventHandler<ProgressInfo> _progressEventHandler;


        public static event EventHandler<ProgressInfo> PropgressEventHandler
        {
            add
            {
                _progressEventHandler += value;
            }
            remove
            {
                if (_progressEventHandler != null)
                    _progressEventHandler -= value;
            }
        }

        private static EventHandler<LogEventInfo> _messageLogEventHandler;


        public static event EventHandler<LogEventInfo> MessageLogEventHandler
        {
            add
            {
                _messageLogEventHandler += value;
            }
            remove
            {
                if (_messageLogEventHandler != null)
                    _messageLogEventHandler -= value;
            }
        }

        //private readonly static Logger _mainLog = LogManager.GetCurrentClassLogger();
        private static readonly Logger _mainLog = LogManager.GetLogger("MainLog");
        private static readonly Logger _errorLog = LogManager.GetLogger("ErrorLog");
        private static readonly Logger _traceLog = LogManager.GetLogger("TraceLog");
        private static readonly Logger _debugLog = LogManager.GetLogger("DebugLog");
        

        public static Logger MainLog
        {
            get { return _mainLog; }
        }

        public static Logger ErrorLog
        {
            get { return _errorLog; }
        }

        public static void MainLogInfo(string messageLog)
        {

            messageLog = PreperingMsg(messageLog);
            _mainLog.Log(LogLevel.Info, messageLog);
            if (_messageLogEventHandler != null)
                _messageLogEventHandler(messageLog, new LogEventInfo(LogLevel.Info, _mainLog.Name, messageLog));
        }

        public static void DebugLogInfo(string messageLog)
        {

            messageLog = PreperingMsg(messageLog);
            _debugLog.Log(LogLevel.Debug, messageLog);
            if (_messageLogEventHandler != null)
                _messageLogEventHandler(messageLog, new LogEventInfo(LogLevel.Debug, _debugLog.Name, messageLog));
        }
        public static void WarningLogInfo(string messageLog)
        {

            messageLog = PreperingMsg(messageLog);
            _mainLog.Warn(messageLog);
            if (_messageLogEventHandler != null)
                _messageLogEventHandler(messageLog, new LogEventInfo(LogLevel.Warn, _mainLog.Name, messageLog));
        }

        public static void TraceLogInfo(string messageLog)
        {
            messageLog = PreperingMsg(messageLog);
            _traceLog.Trace(messageLog);
            if (_messageLogEventHandler != null)
                _messageLogEventHandler(messageLog, new LogEventInfo(LogLevel.Trace, _mainLog.Name, messageLog));
        }

        private static string PreperingMsg(string messageLog)
        {
            return DateTime.Now.ToString("t") + ": " + messageLog;
        }

        public static void ErrorLogInfo(Exception ex)
        {
            _errorLog.Log(LogLevel.Error, ex);
            if (_messageLogEventHandler != null)
            {

                var messageLog = PreperingMsg(ex.Message + ex.InnerException?.Message);
                _messageLogEventHandler(messageLog, new LogEventInfo(LogLevel.Error, _mainLog.Name, messageLog));
            }
        }


        public static void ProgressInfo(object sender = null, int currentValue = 0, string comment = "", int maximumValue = 100)
        {
            if (_progressEventHandler != null)
            {
                _progressEventHandler(sender, new ProgressInfo(currentValue, maximumValue, comment));
            }
        }

    }


}
