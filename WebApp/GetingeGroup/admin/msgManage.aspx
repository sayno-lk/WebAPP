<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="msgManage.aspx.cs" Inherits="WebApp.GetingeGroup.admin.msgManage" %>

<%@ Register TagPrefix="WebApp" Src="~/GetingeGroup/admin/menu.ascx" TagName="menu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>留言审批</title>
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
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <asp:LinkButton ID="btnExit" runat="server" OnClientClick="return btnExit()" OnClick="btnExit_Click">退出</asp:LinkButton>
                </div>
                <div class="top-title">
                    &nbsp;&nbsp;缤蓝后台管理系统<span>--留言审批</span>
                </div>
                <div style="height: 5px;">
                </div>
            </div>
            <WebApp:menu ID="UserTabBar" runat="server" ClassID="1" />
            <div style="text-align: right; color: Black; clear: both; padding: 10px 30px; overflow: hidden;">
                <div style="float: left; display: none;">
                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="left_search">输入留言内容:</asp:Label>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSelect" runat="server" Text="搜索" OnClick="btnSelect_Click" />
                </div>
                <div style="float: right;">
                    <asp:Label ID="lblSumCount" runat="server" Text=""></asp:Label>
                    <asp:Button ID="btnNoDel" runat="server" Text="删除未审批数据" Height="30px" Width="120px"
                        OnClientClick="return reNoDel()" OnClick="btnNoDel_Click" />
                    <asp:Button ID="btnYesDel" runat="server" Text="删除已审批数据" Height="30px" Width="120px"
                        OnClientClick="return reYesDel()" OnClick="btnYesDel_Click" />
                    <asp:Button ID="btnDel" runat="server" Text="删除所有数据" Height="30px" Width="100px"
                        OnClientClick="return reDel()" OnClick="btnDel_Click" />
                </div>
            </div>
            <div class="div3">
                <asp:Repeater ID="repVoteInfo" runat="server" OnItemCommand="repVoteInfo_ItemCommand">
                    <HeaderTemplate>
                        <table class="tblInfo">
                            <tr>
                                <td style="width: 10%">
                                    序号
                                </td>
                                <td style="width: 45%">
                                    留言内容
                                </td>
                                <td style="width: 10%">
                                    主讲编号
                                </td>
                                <td style="width: 10%">
                                    状态
                                </td>
                                <td style="width: 15%">
                                    时间
                                </td>
                                <td>
                                    操作
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="<%#GetClass(Eval("mState")) %>">
                            <td>
                                <%= index++%>
                            </td>
                            <td style="text-align: left;">
                                <%#Eval("mContent")%>
                            </td>
                             <td>
                                <%#Eval("mCode")%>
                            </td>
                            <td>
                                <%#GetMsgState(Eval("mState").ToString())%>
                                <input id="txtVState" type="hidden" value='<%#Eval("mState").ToString()%>' runat="server" />
                            </td>
                            <td>
                                <%#Eval("mTime") == null ? "" : Eval("mTime").ToString()%>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbtUpdate" runat="server" CommandName="update" CommandArgument='<%# Eval("mId") %>'
                                    Text='<%#GetUpdateText(Eval("mState").ToString())%>'>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lbtDel" runat="server" CommandName="del" CommandArgument='<%# Eval("mId") %>'
                                    Text='删除' OnClientClick="return delMsgById(this)">
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <%--           <div style="margin-top: 5px;">
                    当前是第<label id="lblIndex" runat="server"></label>
                    页 ,总共有<label id="lblCount" runat="server"></label>页&nbsp&nbsp&nbsp
                    <asp:Button ID="btnFrist" runat="server" Text="第一页" OnClick="btnFrist_Click" />
                    <asp:Button ID="btnPrv" runat="server" Text="上一页" OnClick="btnPrv_Click" />
                    <asp:Button ID="btnNext" runat="server" Text="下一页" OnClick="btnNext_Click" />
                    <asp:Button ID="btnLast" runat="server" Text="最后一页" OnClick="btnLast_Click" />
                </div>--%>
                <%--       <div style="margin-top: 10px; height: 50px; line-height: 50px; text-align: right;
                    margin-right: 100px;">
                    <asp:Button ID="btnExport" runat="server" Text="导出数据" OnClick="btnExport_Click" Height="52px"
                        Width="106px" />
                </div>--%>
            </div>
            <div style="height: 50px;">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
