using System;
using System.IO;
using System.Text;

namespace OnlineShoppingApp.Utility
{
    public sealed class Log : ILog
    {
        private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());
        private Log()
        {

        }

        public static Log Instance
        {
            get { return instance.Value; }
        }

        public void LogException(Exception exception)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------");
            sb.AppendLine("Exception Log Time : " + exception.LogTime);
            sb.AppendLine("Controller Name : " + exception.ControllerName);
            sb.AppendLine("Action Name : " + exception.ActionName);
            sb.AppendLine("Exception Message : " + exception.Message);
            sb.AppendLine("Stack Trace : " + exception.StackTrace);
            sb.AppendLine("----------------------------------------");

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}
