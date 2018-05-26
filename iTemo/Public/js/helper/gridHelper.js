gridHelper = {
    searchForm: function (gridId, formId) {
        var searchData = $("#" + formId).serializeObject();
        $("#" + gridId).jsGrid("search", searchData);
    },
    searchObject: function (gridId, obj) {
        $("#" + gridId).jsGrid("search", obj);
    },
    addNewRow: function (gridId, item) {
        return $("#" + gridId).editGrid("addNewRow", item);
    },
    updateRow: function (gridId, rowName, item) {
        return $("#" + gridId).editGrid("updateRow", rowName, item);
    },
    removeRow: function (gridId, rowName) {
        $("#" + gridId).editGrid("removeRow", rowName);
    },
    clearListingData: function (gridId) {
        $("#" + gridId).jsGrid("clearData");
    },
    getEditData: function (gridId) {
        return $("#" + gridId).editGrid("validateAndGetData");
    },
    getEditDataWithoutValidate: function (gridId) {
        return $("#" + gridId).editGrid("getData");
    },
    getListingData: function (gridId) {
        return $("#" + gridId).jsGrid("option", "data");
    },
    setEditData: function (gridId, data) {
        return $("#" + gridId).editGrid("setData", data);
    },
    displayDateTime: function (value) {
        if (value == undefined) {
            return "N/A";
        }

        var dateStr = value.replace("/Date(", "").replace(")/", "");
        var date = new Date(1 * dateStr);
        
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var ampm = hours >= 12 ? "PM" : "AM";
        hours = hours % 12;
        hours = hours ? hours : 12; // the hour '0' should be '12'
        minutes = minutes < 10 ? "0" + minutes : minutes;
        var strTime = hours + ":" + minutes + " " + ampm;
        return date.getMonth() + 1 + "/" + date.getDate() + "/" + date.getFullYear() + "  " + strTime;
    },
    generateCheckbox: function (value, item) {
        var str = "<input type='checkbox' class='ckb' item-id='" + item.Id + "'";
        if (item.IsDeleted) {
            str += " disabled='disabled'";
        }
        str += " >";
        return str;
    },
    generateRadioButton: function (value, item) {
        var str = "<input type='radio' name='radioEmail' class='rbt' item-id='" + item.Id + "'";
        if (item.IsDeleted) {
            str += " disabled='disabled'";
        }
        str += " />";
        return str;
    },
    getSearchCondition: function (gridId) {
        return $("#" + gridId).jsGrid("getSearchCondition");
    },
    getItemByRowName: function(gridId, rowName) {
        return $("#" + gridId).editGrid("getItemByRowName", rowName);
    },
    getItemByRowDom: function (gridId, row) {
        if ($("#" + gridId).hasClass("jsgrid")) {
            return $(row).data("JSGridItem");
        } else {
            return $(row).data("EditGridItem");
        }
    },
    getSelectedItem: function(gridId) {
        var selectedRow = $("#" + gridId + " .jsgrid-selected");
        if (selectedRow.length > 0) {
            return $(".jsgrid-selected").data("JSGridItem");
        } else {
            return null;
        }
    },
    refreshSize: function (gridId) {
        if ($("#" + gridId).hasClass("jsgrid")) {
            $("#" + gridId).jsGrid("refresh");
        } else {
            $("#" + gridId).editGrid("refresh");
        }
    },
    loadData: function(gridId) {
        $("#" + gridId).jsGrid("loadData");
    },
    loadGrid: function(gridId, filter) {
        $("#" + gridId).jsGrid("loadGrid", filter);
    },
    resetSortAndPaging: function(gridId, sortField, sortOrder) {
        $('#' + gridId).jsGrid("_clearSortingCss");
        $('#' + gridId).jsGrid("_setSortingParams", sortField, sortOrder);
        //$('#' + gridId).jsGrid("_setSortingCss");
    },
    freezeColumns: function (gridId, numOfCols, isViewMode) {
        var left = $("#" + gridId + " .jsgrid-grid-body").scrollLeft()
            < $("#" + gridId + " .jsgrid-grid-body .jsgrid-table").width()
            - $("#" + gridId + " .jsgrid-grid-body").width() + 16
            ? $("#" + gridId + " .jsgrid-grid-body").scrollLeft()
            : $("#" + gridId + " .jsgrid-grid-body .jsgrid-table").width()
            - $("#" + gridId + " .jsgrid-grid-body").width() + 16;
        if (isViewMode === true) {
            var data = gridHelper.getListingData(gridId);
            if (data == null || data.length === 0) {
                $("#" + gridId + " .jsgrid-header-row th:nth-child(-n+" + numOfCols + ")")
                    .css({ "position": "relative", "left": left, "z-index": 2 });
                return;
            }
        }
        $("#" + gridId + " .jsgrid-header-row th:nth-child(-n+" + numOfCols + "), "
                + "#" + gridId + " .jsgrid-filter-row td:nth-child(-n+" + numOfCols + "), "
                + "#" + gridId + " .jsgrid-insert-row td:nth-child(-n+" + numOfCols + "), "
                + "#" + gridId + " .jsgrid-grid-body tr td:nth-child(-n+" + numOfCols + ")")
            .css({ "position": "relative", "left": left, "z-index": 2 });
        $("#" + gridId + " .jsgrid-filter-row td:nth-child(-n+" + numOfCols + "), "
                + "#" + gridId + " .jsgrid-insert-row td:nth-child(-n+" + numOfCols + "), "
                + "#" + gridId + " .jsgrid-grid-body tr td:nth-child(-n+" + numOfCols + ")")
            .css({ "background-color": "white" });
    }
}
