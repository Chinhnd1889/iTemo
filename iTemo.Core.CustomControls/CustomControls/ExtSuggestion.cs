using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Newtonsoft.Json;

namespace iTemo.Core.CustomControls.CustomControls
{
    public static class ExtSuggestion
	{
        public static MvcHtmlString ExtSingleSuggestionFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, SingleSuggestionOption option, object htmlAttributes = null)
        {
            var html = htmlAttributes == null
                ? new RouteValueDictionary()
                : new RouteValueDictionary(htmlAttributes);
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(htmlHelper.TextBoxFor(expression, html).ToString());
            var controlId = HtmlAttributeHelper.GetControlIdFromExpression(expression);
            stringBuilder.AppendLine("<script>$(function(){");
            stringBuilder.AppendLine($"$('#{controlId}').tokenInput('{option.SearchUrl}',{{");
            stringBuilder.AppendLine("theme: 'facebook',");
            stringBuilder.AppendLine("tokenLimit: 1,");
            stringBuilder.AppendLine("method: 'POST',");
            stringBuilder.AppendLine($"required: {expression.IsRequired().ToString().ToLower()},");
            stringBuilder.AppendLine("queryParam: 'query',");
            stringBuilder.AppendLine("tokenValue: 'Id',");
            stringBuilder.AppendLine("propertyToSearch: 'Name',");
            stringBuilder.AppendLine("minChars: " + option.MinChars + ",");
            if (option.DefaultValue != null)
            {
                stringBuilder.AppendLine($"prePopulate: [{JsonConvert.SerializeObject(option.DefaultValue).Replace("/", "\\/")}],");
            }

            if (!string.IsNullOrEmpty(option.OnAdd))
            {
                stringBuilder.AppendLine($"onAdd: {option.OnAdd},");
            }

            if (!string.IsNullOrEmpty(option.OnDelete))
            {
                stringBuilder.AppendLine($"onDelete: {option.OnDelete},");
            }

            if (!string.IsNullOrEmpty(option.OnReady))
            {
                stringBuilder.AppendLine($"onReady: {option.OnReady},");
            }

            if (!string.IsNullOrEmpty(option.TokenFormatter))
            {
                stringBuilder.AppendLine($"tokenFormatter: {option.TokenFormatter},");
            }

            if (!string.IsNullOrEmpty(option.AdditionalParam))
            {
                stringBuilder.AppendLine($"additionalParam: {option.AdditionalParam},");
            }
            if (option.LocalData != null)
            {
                stringBuilder.AppendLine(
                    $"local_data: {JsonConvert.SerializeObject(option.LocalData)},");
            }
            if (option.CreateNew.HasValue)
            {
                stringBuilder.AppendLine($"createNew: {option.CreateNew.Value.ToString().ToLower()},");
            }

            if (!string.IsNullOrEmpty(option.OnResult))
            {
                stringBuilder.AppendLine($"onResult: {option.OnResult},");
            }

            stringBuilder.AppendLine("});});</script>");
            return CustomControlHelper.GenerateWithValidationMessage(htmlHelper,
                stringBuilder.ToString(), expression);
        }
        public static MvcHtmlString ExtMultiSuggestionFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, MultiSuggestionOption option, object htmlAttributes = null)
        {

            var html = htmlAttributes == null
                ? new RouteValueDictionary()
                : new RouteValueDictionary(htmlAttributes);
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(htmlHelper.TextBoxFor(expression, html).ToString());
            var controlId = HtmlAttributeHelper.GetControlIdFromExpression(expression);
            stringBuilder.AppendLine("<script>$(function(){");
            stringBuilder.AppendLine($"$('#{controlId}').tokenInput('{option.SearchUrl}',{{");
            stringBuilder.AppendLine("theme: 'facebook',");
            if (option.LimitedItem != 0)
            {
                stringBuilder.AppendLine($"tokenLimit: {option.LimitedItem},");
            }
            stringBuilder.AppendLine("method: 'POST',");
            stringBuilder.AppendLine("queryParam: 'query',");
            stringBuilder.AppendLine("tokenValue: 'Id',");
            stringBuilder.AppendLine($"required: {expression.IsRequired().ToString().ToLower()},");
            stringBuilder.AppendLine("propertyToSearch: 'Name',");
            stringBuilder.AppendLine("preventDuplicates: true,");
            stringBuilder.AppendLine("minChars: " + option.MinChars + ",");
            if (option.DefaultValues != null)
            {
                stringBuilder.AppendLine(
                    $"prePopulate: {JsonConvert.SerializeObject(option.DefaultValues).Replace("/", "\\/")},");
            }

            if (!string.IsNullOrEmpty(option.OnAdd))
            {
                stringBuilder.AppendLine($"onAdd: {option.OnAdd},");
            }

            if (!string.IsNullOrEmpty(option.OnDelete))
            {
                stringBuilder.AppendLine($"onDelete: {option.OnDelete},");
            }

            if (!string.IsNullOrEmpty(option.AdditionalParam))
            {
                stringBuilder.AppendLine($"additionalParam: {option.AdditionalParam},");
            }
            if (option.LocalData != null)
            {
                stringBuilder.AppendLine(
                    $"local_data: {JsonConvert.SerializeObject(option.LocalData)},");
            }
            if (option.CreateNew.HasValue)
            {
                stringBuilder.AppendLine($"createNew: {option.CreateNew.Value.ToString().ToLower()},");
            }
            if (!string.IsNullOrEmpty(option.OnResult))
            {
                stringBuilder.AppendLine($"onResult: {option.OnResult},");
            }

            stringBuilder.AppendLine("});});</script>");
            return CustomControlHelper.GenerateWithValidationMessage(htmlHelper,
                stringBuilder.ToString(), expression);
        }

        public static MvcHtmlString ExtMultiSuggestionForCode<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, MultiSuggestionOption option, object htmlAttributes = null)
        {

            var html = htmlAttributes == null
                ? new RouteValueDictionary()
                : new RouteValueDictionary(htmlAttributes);
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(htmlHelper.TextBoxFor(expression, html).ToString());
            var controlId = HtmlAttributeHelper.GetControlIdFromExpression(expression);
            stringBuilder.AppendLine("<script>$(function(){");
            stringBuilder.AppendLine($"$('#{controlId}').tokenInput('{option.SearchUrl}',{{");
            stringBuilder.AppendLine("theme: 'facebook',");
            if (option.LimitedItem != 0)
            {
                stringBuilder.AppendLine($"tokenLimit: {option.LimitedItem},");
            }
            stringBuilder.AppendLine("method: 'POST',");
            stringBuilder.AppendLine("queryParam: 'query',");
            stringBuilder.AppendLine("tokenValue: 'Code',");
            stringBuilder.AppendLine($"required: {expression.IsRequired().ToString().ToLower()},");
            stringBuilder.AppendLine("propertyToSearch: 'Name',");
            stringBuilder.AppendLine("preventDuplicates: true,");
            stringBuilder.AppendLine("minChars: " + option.MinChars + ",");
            if (option.DefaultValues != null)
            {
                stringBuilder.AppendLine(
                    $"prePopulate: {JsonConvert.SerializeObject(option.DefaultValues).Replace("/", "\\/")},");
            }

            if (!string.IsNullOrEmpty(option.OnAdd))
            {
                stringBuilder.AppendLine($"onAdd: {option.OnAdd},");
            }

            if (!string.IsNullOrEmpty(option.OnDelete))
            {
                stringBuilder.AppendLine($"onDelete: {option.OnDelete},");
            }

            if (!string.IsNullOrEmpty(option.AdditionalParam))
            {
                stringBuilder.AppendLine($"additionalParam: {option.AdditionalParam},");
            }
            if (option.LocalData != null)
            {
                stringBuilder.AppendLine(
                    $"local_data: {JsonConvert.SerializeObject(option.LocalData)},");
            }
            if (option.CreateNew.HasValue)
            {
                stringBuilder.AppendLine($"createNew: {option.CreateNew.Value.ToString().ToLower()},");
            }
            if (!string.IsNullOrEmpty(option.OnResult))
            {
                stringBuilder.AppendLine($"onResult: {option.OnResult},");
            }

            stringBuilder.AppendLine("});});</script>");
            return CustomControlHelper.GenerateWithValidationMessage(htmlHelper,
                stringBuilder.ToString(), expression);
        }
    }

    public class SingleSuggestionOption
    {
        public SingleSuggestionOption()
        {
            MinChars = 1;
        }

        public string SearchUrl { get; set; }
        public IEnumerable<object> LocalData { get; set; }
        public string OnAdd { get; set; }
        public string OnDelete { get; set; }
        public string OnReady { get; set; }
        public string TokenFormatter { get; set; }
        public string AdditionalParam { get; set; }
        public string OnResult { get; set; }
        public object DefaultValue { get; set; }
        public bool? CreateNew { get; set; }
        public int MinChars { get; set; }
    }

    public class MultiSuggestionOption
    {
        public MultiSuggestionOption()
        {
            MinChars = 1;
        }

        public string SearchUrl { get; set; }
        public IEnumerable<object> LocalData { get; set; }
        public string OnAdd { get; set; }
        public string OnDelete { get; set; }
        public string AdditionalParam { get; set; }
        public int LimitedItem { get; set; }
        public IEnumerable<object> DefaultValues { get; set; }
        public bool? CreateNew { get; set; }
        public string OnResult { get; set; }
        public int MinChars { get; set; }
    }
    public class SuggestionObject
    {
        public Guid Id { get; set; }

        [AllowHtml]
        public string Name { get; set; }
    }
    public class SuggestionGroupCode
    {
        [AllowHtml]
        public string Code { get; set; }

        [AllowHtml]
        public string Name { get; set; }
    }
    public class SuggestionCompanyForGtp
    {
        public Guid Id { get; set; }

        [AllowHtml]
        public string Name { get; set; }
        [AllowHtml]
        public string Uen { get; set; }
        [AllowHtml]
        public string Status { get; set; }
    }

    public class SuggestionJapCompanyGreenLaneObject
    {
        public Guid Id { get; set; }

        [AllowHtml]
        public string Name { get; set; }
        [AllowHtml]
        public string Uen { get; set; }
        public string CisStatus { get; set; }
    }

    public class ServiceRequestEmail
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string SrFrom { get; set; }
        public Guid ServiceRequestId { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Body { get; set; }
        public Guid OwningUserId { get; set; }
    }

    public class SuggestionDivisionObject
    {
        public Guid Id { get; set; }

        [AllowHtml]
        public string Name { get; set; }
        public string Group { get; set; }
        public string Pillar { get; set; }
        public string Department { get; set; }
    }
    public class SuggestionDepartmentObject
    {
        public Guid Id { get; set; }

        [AllowHtml]
        public string Name { get; set; }
        public string Group { get; set; }
        public string Pillar { get; set; }
        public string Division{ get; set; }
        public string DivisionCrName { get; set; }
    }
    public class SuggestionDepartmentOpptyPfcObject
    {
        public Guid Id { get; set; }
        [AllowHtml]
        public string Name { get; set; }
        public string Division { get; set; }
        public string DivisionCrName { get; set; }
        public string Group { get; set; }
        public string Pillar { get; set; }
        public bool IsCg { get; set; }
        public bool IsIo { get; set; }
        public bool IsEpg { get; set; }
        public bool IsTpg { get; set; }
        public bool IsCluster { get; set; }
        public bool IsGm { get; set; }

    }
    public class SuggestionDivisionOpptyPfcObject
    {
        public Guid Id { get; set; }
        [AllowHtml]
        public string Name { get; set; }
        public string Group { get; set; }
        public string Pillar { get; set; }
        public string Department { get; set; }
        public bool IsCg { get; set; }
        public bool IsIo { get; set; }
        public bool IsEpg { get; set; }
        public bool IsTpg { get; set; }
        public bool IsCluster { get; set; }
        public bool IsGm { get; set; }
    }
}
