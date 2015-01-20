

function GetRecordsWithDifferentPageSize()
{
    $("#hdnPageSize").val($("#drpNoOfRecords").val());
    
}

function GetEventLogs(pageSize, pageIndex) {
    var URL = "/api/sitecore/EventLog/GetEventLogs";
    var finalURL = getEventLogsURL(URL, pageSize, pageIndex);
    $("#dvEventLogList").load(finalURL);
}

function UpdateHiddenFields() {
    $("#hdnFromDate").val($("#txtFromDate").val());
    $("#hdnToDate").val($("#txtToDate").val());
    $("#hdnErrorLevels").val($("#drpErrorLevels").val());
    $("#hdnLogMessage").val($("#txtLogMessage").val());
   // $("#hdnNoOfRecords").val($("#drpNoOfRecords").val());
}

function getEventLogsURL(URL, pageSize, pageIndex) {

    var fromDate = $("#hdnFromDate").val(),
            toDate = $("#hdnToDate").val(),
            level = $("#hdnErrorLevels").val(),
            message = $("#hdnLogMessage").val(),
            pageSize = 10,
            pageIndex = pageIndex;

    URL = URL + "?FromDate=" + fromDate + "&ToDate=" + toDate + "&Level=" + level + "&Message=" + message
        + "&PageSize=" + pageSize + "&PageIndex=" + pageIndex;
    return URL;

}

function GetPageNumbers(id) {
    $(".tr-records").hide();
    $("#tr-" + id).show();

}

function ShowDetails(id) {
    //var records = $("#trRecords-" + id).text();
    var records = $("#tdException-" + id).text();
    $("#dvShowErrorDetails").text(records);
    $("#dvShowErrorDetails").dialog();
    $(".selector").dialog({
        closeOnEscape: true,
        minHeight: 250,
        minWidth: 350,
        modal: true,
        resizable: false,
        draggable: false
    });
    
}
