using System;

namespace OnlineShoppingApp.Utility
{
    public class Exception
    {
        public DateTime LogTime { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
    }
}
