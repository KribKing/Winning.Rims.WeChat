using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winning.Rims.WeChat.Core
{
    public class LogManager
    {
        private static ILog _log;
        public static ILog Log
        {
            get
            {
                if (_log == null)
                {
                    _log = log4net.LogManager.GetLogger("LogManager");
                }
                return _log;
            }
        }

        public static void Error(string message, Exception ex = null)
        {
            if (ex == null)
            {
                Log.Error(message);
            }
            else
            {
                Log.Error(message, ex);
            }
        }

        public static void Info(string message, Exception ex = null)
        {
            if (ex == null)
            {
                Log.Info(message);
            }
            else
            {
                Log.Info(message, ex);
            }
        }

        public static void Debug(string message, Exception ex = null)
        {
            if (ex == null)
            {
                Log.Debug(message);
            }
            else
            {
                Log.Debug(message, ex);
            }
        }

        public static void Warn(string message, Exception ex = null)
        {
            if (ex == null)
            {
                Log.Warn(message);
            }
            else
            {
                Log.Warn(message, ex);
            }
        }

        public static void Fatal(string message, Exception ex = null)
        {
            if (ex == null)
            {
                Log.Fatal(message);
            }
            else
            {
                Log.Fatal(message, ex);
            }
        }
    }
}
