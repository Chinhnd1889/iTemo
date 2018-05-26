using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace iTemo.Core.CustomControls.CustomControls
{
    public static class ExtTextBox
    {
        public static MvcHtmlString ExtTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, string format = null )
        {
            var html = HtmlAttributeHelper.AddDefaultClass(htmlAttributes);
            var maxLength = expression.MaxLength();
            html = HtmlAttributeHelper.AddMaxLength(html, maxLength != 0 ? maxLength : 255);

            return CustomControlHelper.GenerateWithValidationMessage(htmlHelper,
                !string.IsNullOrEmpty(format)
                    ? htmlHelper.TextBoxFor(expression, format, html).ToString()
                    : htmlHelper.TextBoxFor(expression, html).ToString(), expression);
        }
    }
}