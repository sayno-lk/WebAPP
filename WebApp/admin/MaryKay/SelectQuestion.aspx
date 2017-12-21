<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectQuestion.aspx.cs"
    Inherits="WebApp.admin.MaryKay.SelectQuestion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>缤蓝后台管理系统</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="js/load-image.all.min.js" type="text/javascript"></script>
    <script src="js/regValidate.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            width: 100%;
            margin: 0px;
            padding: 0px;
            color: #000;
        }
        .myform
        {
            margin: auto;
            max-width: 80%;
            min-width: 340px;
        }
        .Top
        {
            width: auto;
            background-color: #f5f4f2;
        }
        .head
        {
            width: 100%;
            background: #9c9e9c;
            height: auto;
            float: left;
            color: #FFF;
        }
        
        .head img
        {
            margin-left: 8%;
            float: left;
        }
        
        .top-title
        {
            font-size: 35px;
            line-height: 100px;
            text-align: left;
            height: 100px;
        }
        .top-title span
        {
            margin-left: 20px;
            color: yellow;
            font-size: 20px;
            font-family: 微软雅黑;
        }
        .div3
        {
            padding: auto;
            margin: auto;
            width: 95%;
            text-align: center;
            background-color: #FFF;
            border-radius: 10px;
            padding: 10px;
            border: 1px solid #9c9e9c;
            -moz-box-shadow: 3px 3px 4px #9c9e9c;
            -webkit-box-shadow: 3px 3px 4px #9c9e9c;
            box-shadow: 3px 3px 4px #9c9e9c;
            background: #FFF;
            filter: progid:DXImageTransform.Microsoft.Shadow(Strength=4, Direction=135, Color='#FFF');
        }
        .left_search
        {
            margin-left: 20px;
        }
        
        table.tblInfo
        {
            border-collapse: collapse;
            border: none;
            width: 100%;
        }
        .tblInfo td
        {
            height: 50px;
            border: 1px solid #9c9e9c;
        }
        .tblInfo .class1, .tblInfo .class1 a
        {
            color: black;
        }
        .tblInfo .class2, .tblInfo .class2
        {
            color: blue;
        }
        .tblInfo .class3, .tblInfo .class3 a
        {
            color: red;
        }
        .tblInfo .class1 a
        {
        }
    </style>
    <script type="text/javascript">
        function btnExit() {
            confirm("确定退出吗？")
            {
                return true;
            }
            return false;
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <div class="myform">
        <div class="mycontent">
            <div class="head">
                <div style="height: 5px; text-align: right; margin-right: 20px;">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <%--  <asp:LinkButton ID="btnExit" runat="server" OnClientClick="return btnExit()" OnClick="btnExit_Click">退出</asp:LinkButton>--%>
                </div>
                <div class="top-title">
                    &nbsp;&nbsp;缤蓝后台管理系统--玫琳凯合照上传
                </div>
                <div style="height: 5px;">
                </div>
            </div>
            <div style="text-align: right; color: Black; clear: both; padding: 10px 30px; overflow: hidden;">
                <div style="float: left;">
                    <asp:Button ID="btnSelectPro1" runat="server" Text="刷新" Height="40px" Width="106px"
                        OnClick="btnSelectPro1_Click" />
                    <asp:Button ID="btnQuestion" runat="server" Text="开启问卷" Height="40px" 
                        Width="106px" onclick="btnQuestion_Click" />
                    <asp:Button ID="btnPhoto" runat="server" Text="开启照片" Height="40px" 
                        Width="106px" onclick="btnPhoto_Click" />
                </div>
                <div style="float: right;">
                    <asp:Label ID="lblSumCount" runat="server" Text="访问量"></asp:Label>
                </div>
            </div>
            <div class="middle">
                <asp:Repeater ID="repTaskInfo" runat="server">
                    <HeaderTemplate>
                        <table class="tblInfo">
                            <tr>
                                <td>
                                    序号
                                </td>
                                <td>
                                    姓名
                                </td>
                                <td>
                                    编号
                                </td>
                                <td>
                                    手机号码
                                </td>
                                <td>
                                    题目1
                                </td>
                                <td>
                                    题目2
                                </td>
                                <td>
                                    题目3
                                </td>
                                <td>
                                    题目4
                                </td>
                                <td>
                                    题目5
                                </td>
                                <td>
                                    题目6
                                </td>
                                <td>
                                    题目7
                                </td>
                                <td>
                                    题目8
                                </td>
                                <td>
                                    题目9
                                </td>
                                <td>
                                    题目10
                                </td>
                                <td>
                                    备注4
                                </td>
                                <td>
                                    备注6
                                </td>
                                <td>
                                    时长
                                </td>
                                <td>
                                    提交时间
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# (PageIndex-1)*PageCount+ (++i)%>
                            </td>
                            <td>
                                <%#Eval("AnswerName")%>
                            </td>
                            <td>
                                <%#Eval("AnswerNumber")%>
                            </td>
                            <td>
                                <%#Eval("AnswerPhone")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer1")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer2")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer3")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer4")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer5")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer6")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer7")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer8")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer9")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer10")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer11")%>
                            </td>
                            <td>
                                <%#Eval("AnswerAnswer12")%>
                            </td>
                            <td>
                                <%#Eval("AnswerDuration")%>
                            </td>
                            <td>
                                <%#Eval("AnswerTime")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <div style="margin-top: 5px;">
                    当前是第<label id="lblIndex" runat="server"></label>
                    页 ,总共有<label id="lblCount" runat="server"></label>页&nbsp&nbsp&nbsp
                    <asp:Button ID="btnFrist" runat="server" Text="第一页" OnClick="btnFrist_Click" />
                    <asp:Button ID="btnPrv" runat="server" Text="上一页" OnClick="btnPrv_Click" />
                    <asp:Button ID="btnNext" runat="server" Text="下一页" OnClick="btnNext_Click" />
                    <asp:Button ID="btnLast" runat="server" Text="最后一页" OnClick="btnLast_Click" />
                </div>
                <div style="margin-top: 10px; height: 50px; line-height: 50px; text-align: right;
                    margin-right: 100px;">
                    <asp:Button ID="btnExport" runat="server" Text="导出数据" OnClick="btnExport_Click" Height="52px"
                        Width="106px" />
                </div>
                <div style="margin-top: 10px; height: 50px; line-height: 50px; text-align: right;">
                    <%-- <a href="Export.aspx" style="font-size: 22px; text-decoration: none;">查看详情</a>--%>
                </div>
            </div>
            <div style="height: 50px;">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
