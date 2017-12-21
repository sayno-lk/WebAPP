<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Speaker.aspx.cs" Inherits="WebApp.GetingeGroup.Speaker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <title></title>
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-2.1.3.min.js" type="text/javascript"></script>
    <script src="../js/getUrl.js" type="text/javascript"></script>
    <style type="text/css">
        .wrap-msg-box
        {
            width: 100%;
            position: relative;
            margin: auto;
        }
        .wrap-msg-box textarea
        {
            position: absolute;
            width: 80%;
            height: 80%;
            top: 10%;
            left: 10%;
            border: none;
            background: none;
            outline: none;
            -webkit-appearance: none;
            font-size: 16px;
        }
        .btn-box .input
        {
            width: 40%;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div class="wrap " id="scene" style="">
        <div class="div_top">
            <img src="img/1.jpg" class="w-img" runat="server" id="speakerImg" />
        </div>
        <div class="wrap-msg-box">
            <img src="img/textbg.jpg" class="w-img" />
            <textarea placeholder="Input Your Message Here..." class="textarea" id="txtMsg" maxlength="150"></textarea>
        </div>
        <div class="btn-box rel">
            <input type="button" id="btn_msg" class="input" onclick="addMsg()" />
            <img src="images/submit-btn.png" class="w-img" />
        </div>
        <div class="wrap-bottom">
        </div>
    </div>
    </form>
    <script type="text/javascript">
        var id = "";
        $(window).load(function () {
            id = GetQueryString("id");
            if (id == null || id == "") {
                showDialog("请先登录", "login.html");
                return;
            }
        });
        function addMsg() {
            var postdata = {};
            postdata.action = "addMsg"; //验证经销商编号
            postdata.mCode = id;
            postdata.content = $("#txtMsg").val();
            if (postdata.content == "") {
                alert("请输入留言内容！");
                return;
            }
            $.ajax({
                url: 'ajax/getingeGroup.ashx',
                type: "post",
                data: postdata,
                dataType: 'json',
                beforeSend: function () {
                    //$("#p4_tip_img").show();
                },
                error: function (e) {
                    alert("系统繁忙，请稍后...");
                },
                success: function (r) {
                    if (r.data_relult == "1") {
                        location.href = window.location;
                    }
                    else {
                        alert(r.data_msg);
                        return;
                    }
                }
            });
        }
    </script>
</body>
</html>
