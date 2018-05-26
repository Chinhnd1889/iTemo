using iTemo.Core;
using iTemo.Core.CustomControls.CustomControls;
using iTemo.jsGrid;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace iTemo.Areas.Product.Models
{
    public class ProductSearchViewModel
    {
        public Guid? Id { get; set; }

        public Grid ProductGrid { get; set; }

        public IEnumerable<SelectListItem> ViewNameListItems { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = Constants.Messages.CommonMsg005)]
        public SuggestionObject Assignee { get; set; }
    }
}