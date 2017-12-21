/*
* 注意：
* 1. 所有的JS接口只能在公众号绑定的域名下调用，公众号开发者需要先登录微信公众平台进入“公众号设置”的“功能设置”里填写“JS接口安全域名”。
* 2. 如果发现在 Android 不能分享自定义内容，请到官网下载最新的包覆盖安装，Android 自定义分享接口需升级至 6.0.2.58 版本及以上。
* 3. 完整 JS-SDK 文档地址：
*
* 如有问题请通过以下渠道反馈：
* 邮箱地址：weixin-open@qq.com
* 邮件主题：【微信JS-SDK反馈】具体问题
* 邮件内容说明：用简明的语言描述问题所在，并交代清楚遇到该问题的场景，可附上截屏图片，微信团队会尽快处理你的反馈。
*/

var title = "JS-SDK测试";
var desc = "详情描述";
$(window).ready(function () {
    var postdata = {};
    postdata.action = "js_sdk"; //分享
    postdata.url = window.location.href;
    $.ajax({
        url: '/API/wxJsSdk.ashx',
        type: "post",
        data: postdata,
        beforeSend: function () {
            //alert("开始");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert("error ....." + errorThrown);
        },
        success: function (msg) {
            //alert("系统繁忙，请稍后...");
            //alert("appid: " + msg.appid + "; timestamp:" + msg.timestamp + " ; nonceStr:" + msg.nonceStr + "; signature:" + msg.signature);
            $("#js_sdk11").append(msg);
        }
    });
});
wx.ready(function () {
    //wx.hideOptionMenu();

    // 2.1 监听“分享给朋友”，按钮点击、自定义分享内容及分享结果接口
    wx.onMenuShareAppMessage({
        title: title,
        desc: desc,
        link: 'http://wechatweb.77hudong.com/hp/index.html',
        imgUrl: 'http://wechatweb.77hudong.com/hp/images/icon.png',
        trigger: function (res) {
            //alert('用户点击发送给朋友');
        },
        success: function (res) {
            //alert('已分享');
        },
        cancel: function (res) {
            //alert('已取消');
        },
        fail: function (res) {
            //alert(JSON.stringify(res));
        }
    });
    //alert('已注册获取“发送给朋友”状态事件');

    // 2.2 监听“分享到朋友圈”按钮点击、自定义分享内容及分享结果接口
    wx.onMenuShareTimeline({
        title: title,
        link: 'http://wechatweb.77hudong.com/hp/index.html',
        imgUrl: 'http://wechatweb.77hudong.com/hp/images/icon.png',
        trigger: function (res) {
            //alert('用户点击分享到朋友圈');
        },
        success: function (res) {
            //alert('已分享');
        },
        cancel: function (res) {
            //alert('已取消');
        },
        fail: function (res) {
            //alert(JSON.stringify(res));
        }
    });
    alert('已注册获取“分享到朋友圈”状态事件');
});
wx.error(function (res) {
    //alert("err....:" + res.errMsg);
    var postdata = {};
    postdata.action = "error"; //分享
    postdata.url = window.location.href;
    $.ajax({
        url: '/ajax/wxJsSdk.ashx',
        type: "post",
        data: postdata,
        beforeSend: function () {
            //alert("开始");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert("error ....." + errorThrown);
        },
        success: function (msg) {
            //alert("系统繁忙，请稍后...");
            //alert("appid: " + msg.appid + "; timestamp:" + msg.timestamp + " ; nonceStr:" + msg.nonceStr + "; signature:" + msg.signature);
            $("#js_sdk11").append(msg);
        }
    });
});