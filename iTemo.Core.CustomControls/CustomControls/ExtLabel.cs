using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace iTemo.Core.CustomControls.CustomControls
{
    public static class ExtLabel
    {
        public static MvcHtmlString ExtLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, bool checkRequired = true, object htmlAttributes = null)
        {
            var propertyName = ExpressionHelper.GetExpressionText(expression);
            var property = htmlHelper.ViewData.ModelMetadata.Properties.First(p => p.PropertyName == propertyName);
            var displayName = string.IsNullOrEmpty(property.DisplayName) ? propertyName : property.DisplayName;

            if (checkRequired && expression.IsRequired())
            {
                displayName += "<i class=\"required\">*</i>";
            }

            var tempInput = htmlHelper.LabelFor(expression, "#?replace?#", htmlAttributes).ToString();
            tempInput = tempInput.Replace("#?replace?#", displayName);
            return new MvcHtmlString(tempInput);
        }

        public static MvcHtmlString ExtLabelWithDefaultClassFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, bool checkRequired = true, object htmlAttributes = null)
        {
            var propertyName = ExpressionHelper.GetExpressionText(expression);
            var property = htmlHelper.ViewData.ModelMetadata.Properties.First(p => p.PropertyName == propertyName);
            var displayName = string.IsNullOrEmpty(property.DisplayName) ? propertyName : property.DisplayName;

            if (checkRequired && expression.IsRequired())
            {
                displayName += "<i class=\"required\">*</i>";
            }

            var html = HtmlAttributeHelper.AddDefaultClassForLabel(htmlAttributes);

            var tempInput = htmlHelper.LabelFor(expression, "#?replace?#", html).ToString();
            tempInput = tempInput.Replace("#?replace?#", displayName);
            return new MvcHtmlString(tempInput);
        }
    }
}