using System;
using System.Web.Mvc;
using log4net;
using RobotArm.Common.Logging;

namespace RobotArm.WebApp.ErrorHandlers
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        private readonly ILog _logger;

        public CustomHandleErrorAttribute()
        {
            // TODO: Refactor, factory should be injected!
            _logger = LoggerFactory.GetLogger(ELogger.Common);
        }

        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;

            _logger.Error($"Error catched in {nameof(CustomHandleErrorAttribute)}", ex);

            var model = new HandleErrorInfo(filterContext.Exception, 
                filterContext.HttpContext.Request.RequestContext.RouteData.Values["controller"].ToString(),
                filterContext.HttpContext.Request.RequestContext.RouteData.Values["action"].ToString());

            filterContext.Result = new ViewResult()
            {                
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
        }
    }
}