using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingApp.UI.Models
{
    [NotMapped]
    public class Alert
    {
        public Alert(string alertClass, string message)
        {
            AlertClass = alertClass;
            Message = message;
        }

        public string AlertClass { get; set; }
        public string Message { get; set; }
    }
}