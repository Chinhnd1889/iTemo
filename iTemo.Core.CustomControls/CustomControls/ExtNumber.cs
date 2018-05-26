using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace iTemo.Core.CustomControls.CustomControls
{
    public static class ExtNumber
    {
        public static MvcHtmlString ExtNumberFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, NumberOption option = null, object htmlAttributes = null)
        {
            var html = HtmlAttributeHelper.AddDefaultClass(htmlAttributes);
            var maxLength = expression.MaxLength();
            html = HtmlAttributeHelper.AddMaxLength(html, maxLength != 0 ? maxLength : 255);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(htmlHelper.TextBoxFor(expression, html).ToString());
            var controlId = HtmlAttributeHelper.GetControlIdFromExpression(expression);

            stringBuilder.AppendLine("<script>$(function(){");
            var options = new List<string>()
            {
                "aSep: ''",
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
                if (!string.IsNullOrEmpty(option.MRound))
                {
                    options.Add($"mRound: '{option.MRound}'");
                }
                if (option.NumberOfDecimal.HasValue)
                {
                        options.Add($"mDec : {option.NumberOfDecimal.Value}");
                }
                if (!option.APad)
                {
                    options.Add("aPad : false");
                }
            }
            var optionsStr = string.Join(", ", options);
            stringBuilder.AppendLine($"$('#{controlId}').autoNumeric('init', {{{optionsStr}}});");
            stringBuilder.AppendLine("});</script>");
            return CustomControlHelper.GenerateWithValidationMessage(htmlHelper,
                stringBuilder.ToString(), expression);
        }
        public static MvcHtmlString ExtNumberLargeFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, NumberOptionLarge option = null, object htmlAttributes = null)
        {
            var html = HtmlAttributeHelper.AddDefaultClass(htmlAttributes);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(htmlHelper.TextBoxFor(expression, html).ToString());
            var controlId = HtmlAttributeHelper.GetControlIdFromExpression(expression);

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
                    options.Add("aPad : false");
                }
            }
            var optionsStr = string.Join(", ", options);
            stringBuilder.AppendLine($"$('#{controlId}').autoNumeric('init', {{{optionsStr}}});");
            stringBuilder.AppendLine("});</script>");
            return CustomControlHelper.GenerateWithValidationMessage(htmlHelper,
                stringBuilder.ToString(), expression);
        }


    }
   
    public class NumberOption
    {
        public double? Min { get; set; }
        public double? Max { get; set; }
        public string ASign { get; set; }
        public string PSign { get; set; }
        public bool APad { get; set; }
        public int? NumberOfDecimal { get; set; }
        public string MRound { get; set; }

        public NumberOption()
        {
            APad = true;
        }
    }
    public class NumberOptionLarge
    {
        public double? Min { get; set; }
        public double? Max { get; set; }
        public int? MaxLength { get; set; }
        public string ASign { get; set; }
        public string PSign { get; set; }
        public int? NumberOfDecimal { get; set; }
        public bool APad { get; set; }
        public NumberOptionLarge()
        {
            APad = true;
        }
    }
}