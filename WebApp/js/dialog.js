$(window).ready(function () {
    $("#dialog").html('<div class="dialog-max"></div>' +
        '<div class="dialog-content">' +
            '<span class="dialog-title">提示</span>' +
            '<div class="dialog-msg-box">' +
                '<div id="dialogMsg" class="dialog-msg"></div>' +
            '</div>' +
            '<div class="dialog-bottom">' +
                '<input type="hidden" id="isSkipUrl" value="false" />' +
                '<input type="button" name="name" id="dialog_btn_close" onclick="closeDialog()" value="确  定" />' +
            '</div>' +
        '</div>');
});
//弹出层
function showDialog(dialogMsg, isSkipUrl) {
    $("#isSkipUrl").val(isSkipUrl);
    $("#dialog").show();
    $("#dialogMsg").html(dialogMsg);
}
function closeDialog() {
    $("#dialog").hide();
    $("#dialog #dialogMsg").html("");
    var isSkipUrl = $("#dialog #isSkipUrl").val();
    if (isSkipUrl != "") {
        if (isSkipUrl == "closeWindow") {
            //alert("关闭");
            wx.closeWindow();
        } else {
            window.location.href = isSkipUrl;
        }
    }
}