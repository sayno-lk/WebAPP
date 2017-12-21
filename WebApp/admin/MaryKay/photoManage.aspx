<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="photoManage.aspx.cs" Inherits="WebApp.admin.MaryKay.photoManage" %>

<%@ Register TagPrefix="WebApp" Src="~/admin/MaryKay/menu.ascx" TagName="menu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>缤蓝后台管理系统</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="js/load-image.all.min.js" type="text/javascript"></script>
    <script src="js/regValidate.js" type="text/javascript"></script>
    <script type="text/javascript">
        function btnExit() {
            if (confirm("确定退出吗？")) {
                return true;
            }
            return false;
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <input type="hidden" id="txtQrUrl" value="" runat="server" />
    <div class="myform">
        <div class="mycontent">
            <div class="head">
                <div style="height: 5px; text-align: right; margin-right: 20px;">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <asp:LinkButton ID="btnExit" runat="server" OnClientClick="return btnExit()" OnClick="btnExit_Click">退出</asp:LinkButton>
                </div>
                <div class="top-title">
                    &nbsp;&nbsp;缤蓝后台管理系统--玫琳凯合照上传
                </div>
                <div style="height: 5px;">
                </div>
            </div>
            <div>
                <WebApp:menu ID="UserTabBar" runat="server" ClassID="1" />
            </div>
            <div style="text-align: left; color: Black; clear: both; padding: 10px 30px; overflow: hidden;">
                <%--    <a href="ProjectList.aspx">返回列表页</a><a href="UserList.aspx">查看签到</a>--%>
            </div>
            <div class="middle">
                <div class="wrap">
                    <div class="content" id="addContent">
                        <div class="item">
                            <div class="fl i-left">
                                <span class="i-span1">项目名称</span>
                            </div>
                            <div class="fl i-right i-shadow">
                               <%-- <input type="text" id="txtProName" value="" class="i-input" />--%>
                                <span class="i-proName">MaryKay1照片上传</span>
                            </div>
                        </div>
                        <div class="item">
                            <div class="fl i-left">
                                <span class="i-span1">照片</span>
                            </div>
                            <div class="fl i-right ">
                                <div class="i-proBg">
                                    <img src="/MaryKayUploadImg/photo.jpg" id="pro_img" alt="" />
                                    <input type="file" id="FileUpload" class="fileUpload" onchange="openImage()" name="name" />
                                    <div class="i-upload-tip">
                                        <span class="i-span2 i-upload-tip-span" id="fileUpload_tip">点击图片可修改</span>
                                        <div class="i-upload-tip-bg">
                                        </div>
                                    </div>
                                </div>
                                <p>
                                    证书图片，点击上面图片可修改
                                </p>
                            </div>
                        </div>
                        <%--    <div class="item">
                            <div class="fl i-left">
                                <span class="i-span1">图片修改</span>
                            </div>
                            <div class="fl i-right">
                                <div class="vcimg">
                                    <div class="vcimg-show">
                                        <span class="i-span2" id="Span1">修改</span>
                                        <input type="file" id="FileUpload1" class="fileUpload" onchange="openImage()" name="name" />
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                        <div class="item" style="padding-bottom: 30px">
                            <input type="button" name="name" value="提交" class="i-btn" onclick="addProject()" />
                        </div>
                    </div>
                    <!-- 二维码图片预览 End -->
                    <div class="content" id="qrContent" style="display: none;">
                        <div class="qrcode">
                            <div class="qr-title">
                                <span class="qr-span1">图片预览</span>
                            </div>
                            <div class="qr-conent">
                                <img src="" id="qr_img" alt="证书" runat="server" />
                            </div>
                            <div id="proUrl" class="qr-proUrl">
                            </div>
                            <div class="qr-bottom">
                                <input type="button" id="btn_BackList" class="qr-btn" value="返回列表页" />
                                <%--  <asp:Button ID="BtnDown" runat="server" CssClass="qr-btn" Text="下  载" OnClick="BtnDown_Click" />--%>
                                <input type="button" id="btn_GoAdd" class="qr-btn" value="继续添加" />
                            </div>
                        </div>
                    </div>
                    <!-- 二维码图片预览 End -->
                </div>
            </div>
            <div style="height: 50px;">
            </div>
        </div>
    </div>
    <!-- 弹出层 Begin -->
    <div class="dialog">
        <div class="dialog-max">
        </div>
        <div class="dialog-content">
            <span class="dialog-title">提示</span>
            <div class="dialog-tip">
                <p id="dialogMsg">
                </p>
                <div class="dialog-bottom">
                    <input type="button" name="name" id="dialog_btn_close" value="确  定" />
                </div>
            </div>
        </div>
    </div>
    <!-- 弹出层 End -->
    <script type="text/javascript">
        var fileInput;
        var dataload; //图片编码base64
        var ratioImgLoad;
        var vcImgMaxWidth = 1000;
        //选择图片
        function openImage() {
            fileInput = document.getElementById("FileUpload");
            var file = fileInput.files[0];
            var imageType = /image.*/;
            if (file.type.match(imageType)) {
                var options = {
                    canvas: true,
                    maxWidth: vcImgMaxWidth,
                    maxHeight: vcImgMaxWidth
                };
                loadImage.parseMetaData(file, function (data) {
                    if (data.exif) {
                        options.orientation = data.exif.get('Orientation');
                    }
                });
                loadImage(
                    file,
                    function (canvasOut) {
                        dataload = canvasOut.toDataURL("image/jpeg", 0.9);
                        var vcimg = document.getElementById("pro_img");
                        vcimg.src = dataload;
                        $("#fileUpload_tip").html("点击图片重新选择");
                    },
                    options
                );
            } else {
                alert("文件格式错误，只能为图片png或jpg格式的图片!");
            }
        }
        function download_file(url) {
            if (typeof (download_file.iframe) == "undefined") {
                var iframe = document.createElement("iframe");
                download_file.iframe = iframe;
                document.body.appendChild(download_file.iframe);
            }
            // alert(download_file.iframe); 
            download_file.iframe.src = url;
            download_file.iframe.style.display = "none";


            $.ajax({
                type: "post",
                async: false,
                url: "AddProject.aspx/DownImgAndSave",
                data: "{'url':'" + $("#qr_img").attr('src').replace(new RegExp("\"", "gm"), "\\\"") + "'}",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //alert(data.d); //?
                },
                error: function (err) {
                    alert("服务器繁忙，请重新扫码");
                }
            });
        }
        //返回列表页
        $("#btn_BackList").bind("click", function () {
            location.href = "ProjectList.aspx";
        });
        //继续添加
        $("#btn_GoAdd").bind("click", function () {
            $("#addContent").show();
            $("#qrContent").hide();
            $("#fileUpload_tip").html("点击图片可修改");
            //dataload = "";
        });
        $("#dialog_btn_close").bind("click", function () {
            $(".dialog").hide();
            $(".dialogMsg").html("");
        });
        //查看图片
        function selectImg() {
            $(".visitingCardShow").show();
        }
        //提交注册信息
        function addProject() {
            //var imgsrc = document.getElementById("vc_img");
            var imgsrc = $("#pro_img").attr('src');
            //先验证，后提交注册信息
            var postdata = {};
            postdata.action = "uploadPhoto"; //用户注册
            //postdata.imgBase64 = dataload;//图片
            postdata.imgBase64 = dataload; //图片
            //postdata.proName = $("#txtProName").val().trim(); //名称
//            if (postdata.proName == "") {
//                showDialog("请输入姓名.");
//                $("#txtName").focus();
//                return;
//            }
            //验证图片
            if (dataload == null || dataload == "") {
                showDialog("请选择图片.");
                return;
            }
            $.ajax({
                url: "ajax/marykayUploadImg.ashx",
                type: "post",
                data: postdata,
                dataType: "json",
                beforeSend: function () {
                    showDialog("正在上传照片，请稍等...");
                },
                error: function (e) {
                    showDialog("系统繁忙，请稍后再试");
                    return;
                },
                success: function (r) {
                    if (r.data_result == "1") {
                        showDialog(r.data_msg);
                        showQr(r.data_Img, r.data_Img);
                        //alert(r.data_msg);
                    } else if (r.data_result == "0") {
                        showDialog(r.data_msg);
                        changeImg();
                    }
                }
            });
        }

        function showQr(url, img) {
            var mydate = new Date();
            var t = mydate.getTime();
            $("#addContent").hide();
            $("#qrContent").show();
            $("#proUrl").html(url);
            $("#qr_img").attr("src", img + "?rand=" + t);
            $("#txtQrUrl").val(img); //保存图片地址
        }
    </script>
    <script type="text/javascript">
        $(window).ready(function () {
            var h = $(document).height();
            //alert(h);
            //$(".wrap").css("min-height", h);
        });
        //使用此方法验证所有text textarea 是否含有非法字符
        $(document).ready(function () {
            $("input[type='text']").each(function (i) {
                $(this).keyup(function () { checkIllegalChar($(this)); });
            });

        });
    </script>
    </form>
</body>
</html>
