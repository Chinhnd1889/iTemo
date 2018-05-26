using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace iTemo.Core.CustomControls.CustomControls
{
    public static class ExtDisplayNumber
    {
        public static MvcHtmlString ExtDisplayNumberFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression, NumberOptionLarge option = null, object htmlAttributes = null)
        {
            var html = htmlAttributes == null
                ? new RouteValueDictionary()
                : new RouteValueDictionary(htmlAttributes);
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(htmlHelper.ExtDisplayWidthId(expression, html).ToString());
            var controlId = HtmlAttributeHelper.GetControlIdFromExpression(expression);
            if (html.ContainsKey("id"))
            {
                var tempId = html["id"].ToString();
                if (!string.IsNullOrEmpty(tempId))
                {
                    controlId = tempId;
                }
               
            }
            stringBuilder.AppendLine("<script>$(function(){");
            var options = new List<string>()
            {
                "aSep: ','",
                "aDec: '.'"
            };

            if (option != null)
            {
                if (option.Min.HasValue)
                {
                    options.Add($"vMin: '{option.Min.Value}'");
                }
                if (option.Max.HasValue)
                {
                    options.Add($"vMax: '{option.Max.Value}'");
                }
                if (!string.IsNullOrEmpty(option.ASign))
                {
                    options.Add($"aSign: '{option.ASign}'");
                }
                if (!string.IsNullOrEmpty(option.PSign))
                {
                    options.Add($"pSign: '{option.PSign}'");
                }
                if (option.NumberOfDecimal.HasValue)
                {
                    options.Add($"mDec : {option.NumberOfDecimal.Value}");
                }
                if (!option.APad)
                {
                    options.Add($"aPad : {Convert.ToBoolean("false")}");
                }
            }
            var optionsStr = string.Join(", ", options);
            stringBuilder.AppendLine($"$('#{controlId}').autoNumeric('init', {{{optionsStr}}});");
            stringBuilder.AppendLine("});</script>");
            return CustomControlHelper.GenerateWithValidationMessage(htmlHelper,
                stringBuilder.ToString(), expression);
        }
    }
}
