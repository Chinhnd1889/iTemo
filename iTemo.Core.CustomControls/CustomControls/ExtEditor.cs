using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace iTemo.Core.CustomControls.CustomControls
{
    public static class ExtEditor
    {
        public static MvcHtmlString ExtEditorFullFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, IEnumerable<TValue>>> expression, bool readOnly = false, object htmlAttributes = null)
        {
            var html = HtmlAttributeHelper.AddDefaultClass(htmlAttributes);
            html = HtmlAttributeHelper.AddTextAreaStyle(html);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(htmlHelper.TextAreaFor(expression, html).ToString());


            var controlId = HtmlAttributeHelper.GetControlIdFromExpression(expression);
            stringBuilder.AppendLine("<script>");
            stringBuilder.AppendLine(readOnly
                ? $"CKEDITOR.replace('{controlId}', {{ readOnly: true }})"
                : $"CKEDITOR.replace('{controlId}')");
            stringBuilder.AppendLine("</script>");

            return CustomControlHelper.GenerateWithValidationMessage(htmlHelper, stringBuilder.ToString(), expression);
        }


        public static MvcHtmlString ExtEditorBasicFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
                    Expression<Func<TModel, IEnumerable<TValue>>> expression, bool readOnly = false, object htmlAttributes = null)
        {
            var html = HtmlAttributeHelper.AddDefaultClass(htmlAttributes);
            html = HtmlAttributeHelper.AddTextAreaStyle(html);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(htmlHelper.TextAreaFor(expression, html).ToString());


            var controlId = HtmlAttributeHelper.GetControlIdFromExpression(expression);
            stringBuilder.AppendLine("<script>");
            stringBuilder.AppendLine(
                readOnly
                    ? $"CKEDITOR.replace('{controlId}', {{ customConfig: 'config-basic.js', readOnly: true }})"
                    : $"CKEDITOR.replace('{controlId}', {{ customConfig: 'config-basic.js' }})");

            stringBuilder.AppendLine("</script>");

            return CustomControlHelper.GenerateWithValidationMessage(htmlHelper, stringBuilder.ToString(), expression);
        }

    }
}
