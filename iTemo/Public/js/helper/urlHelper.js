urlHelper = {
    updateUrl: function(obj) {
        var currentUrl = window.location.href;
        var parts = currentUrl.split("#");
        if (parts.length === 0) {
            return;
        }

        var newUrl = parts[0];
        for (var name in obj) {
            if (!obj.hasOwnProperty(name)) {
                continue;
            }
            newUrl += "#" + encodeURI(name) + "=" + encodeURI(obj[name]);
        }

        history.replaceState(obj, "", newUrl);
    },

    getUrlParams: function() {
        var currentUrl = window.location.href;
        var parts = currentUrl.split("#");

        var obj = {};
        for (var index = 1; index < parts.length; index++) {
            var items = parts[index].split("=");
            if (items.length !== 2) {
                continue;
            }

            var name = decodeURI(items[0]);
            var value = decodeURI(items[1]);
            obj[name] = value;
        }

        return obj;
    }
}