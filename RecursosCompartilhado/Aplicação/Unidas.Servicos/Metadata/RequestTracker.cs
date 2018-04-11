using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Linq;

namespace Unidas.Servicos.Metadata
{
    public class RequestTracker
    {
        public string Status { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStack { get; set; }
        public string RequestPath { get; set; }
        public string Ip { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Metodh { get; set; }
        public string Route { get; set; }
        public double RequestCost { get; set; }

        public RequestTracker() { }

        RequestTracker(HttpContext context)
        {
            RequestPath = context.Request.Path.Value;
            Ip = context.Connection.RemoteIpAddress.ToString();
            Metodh = context.Request.Method;
            Status = "AUDITING";
            ExceptionMessage = string.Empty;
            ExceptionStack = string.Empty;
        }

        public static void Initialize(HttpContext context)
        {
            Update(context, new RequestTracker(context));
        }



        public void Update(ActionExecutingContext context)
        {
            Controller = context.Controller.ToString();
            Action = context.ActionDescriptor.DisplayName;
            Route = context.ActionDescriptor.AttributeRouteInfo.Template;

            Update(context.HttpContext, this);
        }

        public void Update(TimeSpan requestCost)
        {
            RequestCost = requestCost.TotalMilliseconds;
        }

        public void Update(Exception ex)
        {
            Status = "ERROR";
            ExceptionMessage = ex?.Message ?? string.Empty;
            ExceptionStack = ex?.StackTrace ?? string.Empty;
        }

        static void Update(HttpContext context, RequestTracker tracker)
        {
            context.Items[$"{context.Session.Id}.TracedRequest"] = JsonConvert.SerializeObject(tracker);
        }
    }
}
