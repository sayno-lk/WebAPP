//验证数字
function check_validate(value) {    //定义正则表达式部分   
    var reg = new RegExp("^[0-9]*$");
    if (!reg.test(value)) {
        return false;
    }
    return true;
}
//验证邮箱
function IsEmail(yx) {
    var reyx = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return (reyx.test(yx));
}
function IsEmail2(yx) {
    var reyx = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/;
    return (reyx.test(yx));
}
//弹出层
function showDialog(dialogMsg, isSkipUrl) {
    $("#isSkipUrl").val(isSkipUrl);
    $(".dialog").show();
    $("#dialogMsg").html("*" + dialogMsg);
}
//刷新验证码
function changeImg() {
    var imgNode = document.getElementById("codeImg");
    imgNode.src = "ValidateCode.aspx?t=" + (new Date()).valueOf();
}

//验证 是否含有非法字符
function checkIllegalChar(obj) {
    var value = obj.val();
    if (!checkChar(value)) {
        obj.val(value.substring(0, value.length - 1));
        obj.focus();

    }
}
//检查输入中的非法字符
function checkChar(InString) {
    var RefString = "<";
    var RefString2 = "%";
    var RefString3 = "\"";
    var RefString4 = ">";
    var RefString5 = "~";
    var RefString6 = "&";
    var RefString7 = "+";
    var RefString8 = "'";
    for (Count = 0; Count < InString.length; Count++) {
        TempChar = InString.substring(Count, Count + 1);
        if ((RefString.indexOf(TempChar, 0) == 0) || (RefString2.indexOf(TempChar, 0) == 0) || (RefString3.indexOf(TempChar, 0) == 0) || (RefString4.indexOf(TempChar, 0) == 0) || (RefString5.indexOf(TempChar, 0) == 0) || (RefString6.indexOf(TempChar, 0) == 0) || (RefString7.indexOf(TempChar, 0) == 0) || (RefString8.indexOf(TempChar, 0) == 0)) {
            alert("输入字符有误，请重新输入！");
            return (false);
        }
    }
    return (true);
}
