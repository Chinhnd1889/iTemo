suggestionHelper = {
    getData: function(id) {
        var data = $("#" + id).tokenInput('get');
        var settings = $("#" + id).tokenInput('settings');
        if (settings.tokenLimit == 1) {
            // single
            if (data != null && data.length >= 1) {
                return data[0];
            }
        } else {
            // multi
            return data;
        }
    },

    remove: function (id, data) {
        $("#" + id).tokenInput("remove", data);
    },
    add: function (id, data) {
        $("#" + id).tokenInput("add", data);
    },
    clear: function(id) {
        $("#" + id).tokenInput("clear");
    },
    disable: function (id) {
        var $tokenLst = $("#" + id).parent().find(".token-input-list-facebook");
        $tokenLst.addClass("token-disable");
    },
    enable: function (id) {
        var $tokenLst = $("#" + id).parent().find(".token-input-list-facebook");
        $tokenLst.removeClass("token-disable");
    }
}