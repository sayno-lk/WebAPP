<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApp.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>jssdk测试</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link href="css/animation.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-2.1.3.min.js" type="text/javascript"></script>
    <style type="text/css">
        .p {
            text-align: center;
            position: relative;
            margin: auto;
        }

            .p input {
                width: 100px;
                height: 40px;
            }

        .light {
            position: absolute;
            width: 0px;
            height: 0px;
            -webkit-animation: twinkle 2s ease 1.5s infinite;
            -webkit-animation-delay: 2s;
            top: 50%;
            left: 50%;
            -webkit-transform: translateX(-50%) translateY(-50%);
            -moz-transform: translateX(-50%) translateY(-50%);
            -ms-transform: translateX(-50%) translateY(-50%);
            transform: translateX(-50%) translateY(-50%);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
        <div class="p">
            <div class="light" style="border-radius: 25px; background: #ffc0cb;">
            </div>
            <input type="button" value="test" style="" onclick="dark()" />
        </div>
        <script type="text/javascript">
            //        function dark() {
            //            $(".light").css({ width: "10px", height: "10px", left: "20px", top: "20px", opacity: 1 }).animate({ width: "50px", height: "50px", left: "0px", top: "0px", opacity: 0 }, 1000, "linear", a());
            //        }
            function dark() {
                location.href = window.location.href;
            };

        </script>
    </form>
</body>
</html>
