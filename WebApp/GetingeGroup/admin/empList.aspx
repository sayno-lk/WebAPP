<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="empList.aspx.cs" Inherits="WebApp.GetingeGroup.admin.empList" %>
<%@ Register TagPrefix="WebApp" Src="~/GetingeGroup/admin/menu.ascx" TagName="menu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>留言上墙</title>
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
            if (confirm("确定退出吗？")) {
                return true;
            }
            return false;
        }
        //修改
        function updateMsgState(name) {
            var text = $(name).text();
            if (text == "审批") {
                return confirm('你真的要修改吗?');
            } else {
                alert("已审批的不可修改。");
                return false;
            }
        }
        //删除所有的数据
        function reDel() {
            if (confirm("确定删除所有数据吗？")) {
                return true;
            }
            return false;
        }
        //删除未审批的数据
        function reNoDel() {
            if (confirm("确定删除所有未审批的数据吗？")) {
                return true;
            }
            return false;
        }
        //删除已审批的数据
        function reYesDel() {
            if (confirm("确定删除所有已审批的数据吗？")) {
                return true;
            }
            return false;
        }
        //删除已拉取的数据
        function reLaQuDel() {
            if (confirm("确定删除所有已拉取的数据吗？")) {
                return true;
            }
            return false;
        }
        //删除单条数据
        function delMsgById(name) {
            var text = $(name).text();
            if (text == "删除") {
                return confirm('你真的要删除这条数据吗?');
            } else {
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <div class="myform">
        <div class="Top">
            <div class="head">
                <div style="height: 5px; text-align: right; margin-right: 20px;">
                </div>
                <div class="top-title">
                    &nbsp;&nbsp;缤蓝后台管理系统<span>--留言上墙</span>
                </div>
                <div style="height: 5px;">
                </div>
            </div>
            <WebApp:menu ID="UserTabBar" runat="server" ClassID="3" />
            <div style="text-align: right; color: Black; clear: both; padding: 10px 30px; overflow: hidden;">
                <div style="float: left; display: none;">
                </div>
                <div style="float: right;">
                </div>
            </div>
            <div class="div3">
                <asp:Repeater ID="repVoteInfo" runat="server">
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
                                    邮箱
                                </td>
                                <td>
                                    状态
                                </td>
                                <td>
                                    时间
                                </td>
                                <td>
                                    操作
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="<%#GetClass(Eval("eSign")) %>">
                            <td>
                                <%= index++%>
                            </td>
                            <td >
                                <%#Eval("eName")%>
                            </td>
                            <td style="width: 40%; text-align: left;">
                                <%#Eval("eEmail")%>
                            </td>
                            <td>
                                <%#GetMsgState(Eval("eSign").ToString())%>
                            </td>
                            <td>
                                <%#Eval("eSignTime") == null ? "" : Eval("eSignTime").ToString()%>
                            </td>
                            <td>
                                <%-- <asp:LinkButton ID="lbtUpdate" runat="server" CommandName="update" CommandArgument='<%# Eval("msId") %>'
                                    Text='<%#GetUpdateText(Eval("msState").ToString())%>' OnClientClick="return updateMsgState(this)">
                                </asp:LinkButton>
                                <asp:LinkButton ID="lbtDel" runat="server" CommandName="del" CommandArgument='<%# Eval("msId") %>'
                                    Text='删除' OnClientClick="return delMsgById(this)">
                                </asp:LinkButton>--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div style="height: 50px;">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
