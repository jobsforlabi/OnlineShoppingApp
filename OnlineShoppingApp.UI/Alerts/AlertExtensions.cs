using OnlineShoppingApp.UI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Alerts
{
    public static class AlertExtensions
    {
        const string Alerts = "_Alerts";

        public static List<Alert> GetAlerts(this TempDataDictionary tempData)
        {
            if(!tempData.ContainsKey(Alerts))
            {
                tempData[Alerts] = new List<Alert>();
            }

            return (List<Alert>)tempData[Alerts];
        }

        public static ActionResult WithSuccess(this ActionResult innerResult, string message)
        {
            return new AlertActionResult(innerResult, "alert-success", message);
        }

        public static ActionResult WithInfo(this ActionResult innerResult, string message)
        {
            return new AlertActionResult(innerResult, "alert-info", message);
        }

        public static ActionResult WithWarning(this ActionResult innerResult, string message)
        {
            return new AlertActionResult(innerResult, "alert-warning", message);
        }

        public static ActionResult WithError(this ActionResult innerResult, string message)
        {
            return new AlertActionResult(innerResult, "alert-danger", message);
        }
    }
}