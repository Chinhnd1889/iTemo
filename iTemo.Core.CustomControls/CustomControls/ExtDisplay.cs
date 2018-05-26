using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace iTemo.Core.CustomControls.CustomControls
{
    public static class ExtDisplay
    {
        public static MvcHtmlString ExtDisplayFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            
            var tempInput = "<span class='display-control'>" + htmlHelper.DisplayFor(expression, htmlAttributes) + "</span>";
          
            return new MvcHtmlString(tempInput);
        }

        public static MvcHtmlString ExtDisplayWrap<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {

            var tempInput = "<span class='display-control-wrap'>" + htmlHelper.DisplayFor(expression, htmlAttributes) + "</span>";

            return new MvcHtmlString(tempInput);
        }

        public static MvcHtmlString ExtDisplayWidthId<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
           Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            var spanBuilder = new TagBuilder("span");
            var controlId = HtmlAttributeHelper.GetControlIdFromExpression(expression);
            var htmlAttributesDictionary = htmlAttributes as RouteValueDictionary;
            if (htmlAttributesDictionary != null && htmlAttributesDictionary.ContainsKey("id"))
            {
                var tempId = htmlAttributesDictionary["id"].ToString();
                if (!string.IsNullOrEmpty(tempId))
                {
                    controlId = tempId;
                }

            }
            var style = string.Empty;
            if (htmlAttributesDictionary != null && htmlAttributesDictionary.ContainsKey("style"))
            {
                var tempStyle = htmlAttributesDictionary["style"].ToString();
                if (!string.IsNullOrEmpty(tempStyle))
                {
                    style = tempStyle;
                }
            }
            var cssClass = string.Empty;
            if (htmlAttributesDictionary != null && htmlAttributesDictionary.ContainsKey("class"))
            {
                var tempClass = htmlAttributesDictionary["class"].ToString();
                if (!string.IsNullOrEmpty(tempClass))
                {
                    cssClass = tempClass;
                }
            }
            if (!string.IsNullOrEmpty(cssClass))
            {
                spanBuilder.AddCssClass(cssClass);
            }
            spanBuilder.MergeAttribute("id", controlId);
            spanBuilder.MergeAttribute("style",
                !string.IsNullOrEmpty(style) ? style : "display: block;text-align: right");

            spanBuilder.SetInnerText(htmlHelper.DisplayFor(expression, htmlAttributes).ToString());

            return new MvcHtmlString(spanBuilder.ToString());
        }
    }
}