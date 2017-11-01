using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RobotArm.WebApp.Helpers
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString Button(this HtmlHelper helper,
            string innerHtml,
            object htmlAttributes = null)
        {
            return Button(helper, innerHtml,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)
            );
        }

        public static MvcHtmlString Button(this HtmlHelper helper,
            string innerHtml,
            IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button");
            builder.InnerHtml = innerHtml;
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}