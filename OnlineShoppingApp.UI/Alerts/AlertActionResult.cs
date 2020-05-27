using OnlineShoppingApp.UI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Alerts
{
    public class AlertActionResult : ActionResult
    {
        public ActionResult InnerResult { get; set; }
        public string AlertClass { get; set; }
        public string Message { get; set; }

        public AlertActionResult(ActionResult innerResult, string alertClass, string message)
        {
            InnerResult = innerResult;
            AlertClass = alertClass;
            Message = message;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            List<Alert> alerts = context.Controller.TempData.GetAlerts();
            alerts.Add(new Alert(AlertClass, Message));
            InnerResult.ExecuteResult(context);
        }
    }
}