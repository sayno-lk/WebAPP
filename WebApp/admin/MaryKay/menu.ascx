<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="WebApp.admin.MaryKay.menu" %>
<link href="css/menu.css" rel="stylesheet" type="text/css" />
<script src="../../js/jquery-2.1.3.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(window).load(function () {
        init();
    });
    function init() {
        $(".menu-item li").mousemove(function () {
            $(this).children("ul").show().addClass("zoom-out");
        });
        $(".menu-item li").mouseout(function () {
            $(this).children("ul").hide();
        });
    }
</script>
<div class="menu">
    <ul class="menu-item">
        <li id="1"><a href="photoManage.aspx"><i class="icon-thumbs-up"></i>上传合照</a>
            <%--    <ul style="display: none;">
                            <li><a href="#">Web Design</a></li><p style="display: none">
                                Lorem ipsum dolor dit amet</p>
                            <li><a href="#">Hosting</a></li><p style="display: none">
                                Lorem ipsum dolor dit amet</p>
                            <li><a href="#">Design</a>
                                <p style="display: none">
                                    Lorem ipsum dolor dit amet</p>
                            </li>
                            <p style="display: none">
                                Lorem ipsum dolor dit amet</p>
                            <li><a href="#">Consulting</a></li><p style="display: none">
                                Lorem ipsum dolor dit amet</p>
                        </ul>--%>
        </li>
        <li id="2"><a href="zsManage.aspx"><i class="icon-thumbs-up"></i>上传证书</a></li>
       <%-- <li id="4"><a href="QuestionHistory.aspx"><i class="icon-thumbs-up"></i>问答历史记录</a></li>--%>
    </ul>
</div>
<script type="text/javascript">
    $(window).load(function() {
        var id = <%= ClassID%>;
        $("#"+id).addClass("active");
    });
      
</script>
