using System;
using System.Diagnostics;
using System.Threading;
using Interfaces;

namespace LoggingLib
{
   public sealed class LoggingService : ILoggingService
    {
        private static volatile LoggingService _instance;
        private static readonly object SyncRoot = new Object();

        private LoggingService() { }

        public static LoggingService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new LoggingService();
                    }
                }

                return _instance;
            }
        }

       public void Log(string text)
        {
            Trace.Write(text);
        }

        public void WriteLine(string text)
        {
            Trace.WriteLine(text);
        }
    }
}
