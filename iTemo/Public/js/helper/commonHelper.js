commonHelper = {
    htmlEncode: function(value) {
        return $("<div/>").text(value).html();
    },
    htmlDecode: function(value) {
        return $("<div/>").html(value).text();
    },
    urlEncode: function (value) {
        return encodeURI(value);
    },
    urlDecode: function (value) {
        return decodeURI(value);
    },
    setFocus: function (selector) {
        setTimeout(function () {         
            $("#" + selector).focus();
        }, 1000);
    },
    checkDate:function(params) {
        if ($(params).val() !== "") {
            var dateArr = $(params).val().split("/");
            var d = parseInt(dateArr[0], 10),
                    m = parseInt(dateArr[1], 10),
                    y = parseInt(dateArr[2], 10);
            var date = new Date(y, m - 1, d);
            return date.getFullYear() === y && date.getMonth() + 1 === m && date.getDate() === d;
        }
        return false;
    },

    scrollToError: function() {
        $("html,body").animate({
            scrollTop: $(".field-validation-error").eq(0).offset().top - 200
        }, 500);
    },

    disabledForm: function(id) {
        $("#" + id).find("input, select, textarea").prop("disabled", true);
        $("#" + id).find(".hiddenCustomeField").each(function () {
            var elementId = $(this).attr("id");
            suggestionHelper.disable(elementId);
        });

        $("#remarkAttachmentEditorAttachment").hide();
    },

    getRemarkList: function () {
        
        var remarkTextBox = {
            Remark: $("#remarkInput").val()
        };
        var remarkId = $("#remarkId").val();
        var lstRemarks = [];
        if ($("#remarkInput").val() !== "") {
            lstRemarks.push({ Remark: $("#remarkInput").val() });
        }
        $("#remarkAndAttachments").find(".remarksList li").each(function () {
            var id = $(this).attr("id");
            if (id !== remarkId) {
                lstRemarks.push({
                    Remark: commonHelper.htmlDecode($(this).find(".remarksContent").html())
                });
            }
            
        });
        return lstRemarks;
    },

    getKeywordList: function () {
        var lstKeyword = [];
        
        $("#lstKeyword li").each(function () {
            var current = $(this).find("p").html();
            if (current !== undefined) {
                lstKeyword.push({ Keyword: current });
            }
        });

        return lstKeyword;
    },
    createCookie: function(name,value,days) {
        var expires = "";
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days*24*60*60*1000));
            expires = "; expires=" + date.toUTCString();
        }
        document.cookie = name + "=" + value + expires + "; path=/";
    },
    readCookie : function(name){
        var nameEq = name + "=";
        var ca = document.cookie.split(";");
            for(var i=0;i < ca.length;i++) {
                var c = ca[i];
                while (c.charAt(0) === " ") c = c.substring(1,c.length);
                if (c.indexOf(nameEq) === 0) return c.substring(nameEq.length,c.length);
            }
            return null;
    },
    eraseCookie : function(name) {
        commonHelper.createCookie(name, "", -1);
    }
}
