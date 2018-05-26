using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace iTemo.Core.CustomControls.CustomControls
{
	public static class ExtAsset
	{
		private const string JsViewDataName = "RenderJavaScript";
		private const string StyleViewDataName = "RenderStyle";

		public static void AddJavaScript(this HtmlHelper htmlHelper, string scriptUrl)
		{
		    if (htmlHelper.ViewContext.HttpContext.Items[JsViewDataName] is List<string> scriptList)
		    {
		        if (!scriptList.Contains(scriptUrl))
		        {
		            scriptList.Add(scriptUrl);
		        }
		    }
		    else
			{
			    scriptList = new List<string> {scriptUrl};
			    htmlHelper.ViewContext.HttpContext.Items.Add(JsViewDataName, scriptList);
			}
		}

		public static MvcHtmlString RenderJavaScripts(this HtmlHelper htmlHelper)
		{
			var result = new StringBuilder();

		    if (!(htmlHelper.ViewContext.HttpContext.Items[JsViewDataName] is List<string> scriptList))
		        return MvcHtmlString.Create(result.ToString());
		    foreach (var script in scriptList)
		    {
		        result.AppendLine($"<script type=\"text/javascript\" src=\"{script}\"></script>");
		    }

		    return MvcHtmlString.Create(result.ToString());
		}

		public static void AddStyle(this HtmlHelper htmlHelper, string styleUrl)
		{
		    if (htmlHelper.ViewContext.HttpContext.Items[StyleViewDataName] is List<string> styleList)
			{
				if (!styleList.Contains(styleUrl))
				{
					styleList.Add(styleUrl);
				}
			}
			else
			{
			    styleList = new List<string> {styleUrl};
			    htmlHelper.ViewContext.HttpContext.Items.Add(StyleViewDataName, styleList);
			}
		}

		public static MvcHtmlString RenderStyles(this HtmlHelper htmlHelper)
		{
			var result = new StringBuilder();

		    if (!(htmlHelper.ViewContext.HttpContext.Items[StyleViewDataName] is List<string> styleList))
		        return MvcHtmlString.Create(result.ToString());
		    foreach (var script in styleList)
		    {
		        result.AppendLine($"<link href=\"{script}\" rel=\"stylesheet\" type=\"text/css\" />");
		    }

		    return MvcHtmlString.Create(result.ToString());
		}
	}
}
