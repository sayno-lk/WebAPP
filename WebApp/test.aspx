<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebApp.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .item
        {
            display: table;
            height: 200px;
        }
        .item div
        {
            vertical-align: middle;
            display: table-cell;
            height: 200px;
        }
        .i-left
        {
            border: 1px #ddd solid;
            overflow: hidden;
            text-align: center;
        }
        .i-left img
        {
            width: 20%;
        }
        .i-right
        {
            border: 1px #ddd solid;
            overflow: hidden;
            text-align: center;
            display: table-cell;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="item">
        <div class="i-left">
            <img src="images/1.png" /></div>
        <div class="i-right">
            fasdf sadf sdafs</div>
        <div class="i-right">
            fasdf sadf sdafs</div>
    </div>
    <div>
        <style>
            ul
            {
                list-style: none;
            }
            ul li
            {
                float: left;
                width: 80px;
                height: 30px;
                margin-right: 15px;
            }
        </style>
        <ul id="test">
            <li>高铁<input type="checkbox" class="test_1" name="test_1" value="高铁" />
                <label style="overflow: hidden; word-wrap: break-word;">
                    gaotiesfsfssafffasfsfd</label>
            </li>
            <li>飞机<input type="checkbox" class="test_1" name="test_1" value="飞机" />
                <label style="overflow: hidden; word-wrap: break-word;">
                    gaotiesfsfssafffa</label>
            </li>
            <li>自驾<input type="checkbox" class="test_1" name="test_1" value="自驾" />
                <label style="overflow: hidden; word-wrap: break-word;">
                    gaoties</label>
            </li>
            <li>高铁<input type="checkbox" class="test_1" name="test_1" value="高铁1" />
                <label style="overflow: hidden; word-wrap: break-word;">
                    gaotiesfsfssafffasfsfd</label>
            </li>
            <li>飞机<input type="checkbox" class="test_1" name="test_1" value="飞机1" />
                <label style="overflow: hidden; word-wrap: break-word;">
                    gaotiesfsfssafffa</label>
            </li>
            <li>自驾<input type="checkbox" class="test_1" name="test_1" value="自驾1" />
                <label style="overflow: hidden; word-wrap: break-word;">
                    gaoties</label>
            </li>
        </ul>
        <script type="text/javascript">
            $(".test_1").click(function () {
                var value = $(this).val();
                $(".test_1").each(function () {
                    if ($(this).val() != value) {
                        $(this).attr("checked", false);
                    }
                })
            })
        </script>
    </div>
    </form>
</body>
</html>
