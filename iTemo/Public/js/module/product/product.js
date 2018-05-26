var productModule = {
    urlDetailProduct: null,
    urlCreateProduct: null,

    createProduct: function() {
        if (productModule.urlCreateProduct !== null) {
            location.href = productModule.urlCreateProduct;
        }
    },

    deleteProduct: function() {
        if (productModule.urlCreateProduct !== null) {
            location.href = productModule.urlCreateProduct;
        }
    },

    onDataLoaded: function(grid) {
        //var searchCondition = gridHelper.getSearchCondition("gridProductListing");
        //if (searchCondition.ViewName === undefined)
        //    searchCondition.ViewName = "My Accounts";
        //urlHelper.updateUrl(searchCondition);
        //searchCondition.ViewName = encodeURI(searchCondition.ViewName);
        //localStorage.setItem('paramsfilter', JSON.stringify(searchCondition));
    },

    generateProductCodeColumn: function(value, item) {
        if (value) {
            return "<a href='" + productModule.urlDetailProduct + "/" + item.Id + "' >" + value + "</a>";
        } else {
            return "<a href='" + productModule.urlDetailProduct + "/" + item.Id + "' >-----</a>";
        }
    },

    generateCheckBoxColumn: function(value, item) {
        var str = "";
        if (item.IsDeleted) {
            return str;
        }
        str += "<input type='checkbox' value='" + item.Id + "'";
        str += " onChange=productModule.triggerButton(this) >";
        return str;
    },

    triggerButton: function(data) {
        console.log("checkbox");
    },

    search: function(e) {
        if (e.type === "click" || (e.type === "keypress" && e.keyCode === 13)) {
            var viewName = $("#ViewNameListItems option:selected").text();
            var request = {
                Keyword: $("#txtKeyword").val().trim(),
                ViewName: viewName
            };
            gridHelper.searchObject("gridProductListing", request);
        }
    }
}