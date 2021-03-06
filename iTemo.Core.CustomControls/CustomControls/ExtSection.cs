﻿using System;
using System.Web.Mvc;

namespace iTemo.Core.CustomControls.CustomControls
{
	public class ExtSection : IDisposable
	{
		private readonly ViewContext _viewContext;
		public ExtSection(ViewContext viewContext)
		{
			_viewContext = viewContext;
		}

		public void Dispose()
		{
			ExtSectionHelper.EndSection(_viewContext);
			GC.SuppressFinalize(this);
		}
	}

	public static class ExtSectionHelper
	{
		private const string HtmlBeginSection = "<div class=\"box {3} {4} {5}\">" +
												"<div class=\"box-header with-border\">" +
												"<h3 class=\"box-title\">{0}</h3>" +
												"<div class=\"box-tools pull-right\">" +
												"<button type='button' class=\"btn btn-box-tool\" data-widget=\"{1}\">" +
												"<i class=\"fa {2}\"></i>" +
												"</button>" +
												"</div>" +
												"</div>" +
												"<div class=\"box-body\">";

		private const string HtmlEndSection = "</div></div>";


		/// <summary>
		/// This custom control auto rendering section collapse expand
		/// </summary>
		/// <param name="htmlHelper"></param>
		/// <param name="title">title in section header</param>
		/// <param name="mode">'collapse' or 'open'</param>
        /// <param name="styleClass">section box style 'box-default', 'box-warning', 'box-ie' ... follow boostrap classes</param>
		/// <param name="customClass">your custom class</param>
		/// <returns></returns>
        public static ExtSection ExtSectionFor(this HtmlHelper htmlHelper, string title, string mode, string styleClass, string customClass = null)
		{
            if (title == null) title = string.Empty;
		    if (styleClass == null) styleClass = "ie-box";
            if (customClass == null) customClass = string.Empty;

			var viewContext = htmlHelper.ViewContext;
			var icon = "fa-chevron-up";
		    var collapsedBox = string.Empty;
            if (mode != "collapse")
		    {
		        icon = "fa-chevron-down";
		        collapsedBox = "collapsed-box";
		    }
            var htmlBegin = string.Format(HtmlBeginSection, title, mode, icon, styleClass, collapsedBox, customClass );			
			viewContext.Writer.Write(htmlBegin);
			return new ExtSection(viewContext);
		}
		
		public static void EndSection(ViewContext viewContext)
		{
			viewContext.Writer.Write(HtmlEndSection);
		}
	}
}
