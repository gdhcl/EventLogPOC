

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
            message = $("#hdnLogMessage").val();
           
    URL = URL + "?FromDate=" + fromDate + "&ToDate=" + toDate + "&Level=" + level + "&Message=" + message
        + "&PageSize=" + pageSize + "&PageIndex=" + pageIndex;
    return URL;

}

function GetPageNumbers(id) {
    $(".tr-records").hide();
    $("#tr-" + id).show();

}

function ShowDetails(id) {
    var records = $("#tdException-" + id).text();
    $("#dvShowErrorDetails").text(records);
    
    $("#dvShowErrorDetails").dialog({
        closeOnEscape: true,
        minHeight: 250,
        minWidth: 350,
        maxWidth: 350,
        maxHeight:400,
        //modal: true,
        //title="Exception Details"
        resizable: false,
        draggable: false,
        title: "Exception Details"
        
    });
    
}
