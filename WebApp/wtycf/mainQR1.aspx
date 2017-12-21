<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainQR1.aspx.cs" Inherits="WebApp.wtycf.mainQR1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" content="LIPID" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link rel="shortcut icon" type="image/x-icon" href="http://res.wx.qq.com/mmbizwap/zh_CN/htmledition/images/icon/common/favicon22c41b.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title>外滩云财富</title>
    <script src="../js/jquery-2.1.3.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/zepto.min.js"></script>
    <script type="text/javascript" src="js/y29.js"></script>
    <link href="css/index.css?v=1" rel="stylesheet" type="text/css" />
    <link href="css/conent.css?v=1" rel="stylesheet" type="text/css" />
    <script src="../zhiwenTest/scripts/hammer.min.js" type="text/javascript"></script>
    <style type="text/css">
        .intro-bg
        {
            width: 100%;
            height: 100%;
            background: url(img/images/intro2.jpg) no-repeat center center;
            background-size: cover;
            position: absolute;
        }
        .intro-bg .adver
        {
            top: 15%;
            width: 100%;
            position: absolute;
        }
        .intro-bg .adver img
        {
            width: 100%;
            position: absolute;
            top: 0;
            vertical-align: middle;
            border: 0;
        }
        .intro-bg .pointer
        {
            width: 100%;
            height: 150px;
            position: absolute;
            bottom: 6%;
            text-align: center;
            overflow: hidden;
        }
        .intro-bg .font
        {
            color: #fff;
            position: absolute;
            bottom: 44%;
            left: 50%;
            width: 200px;
            text-align: center;
            margin-left: -100px;
            -webkit-transition: all ease 1s 2.4s;
            -o-transition: all ease 1s 2.4s;
            transition: all ease 1s 2.4s;
        }
        .intro-bg .pointer .cursor
        {
            height: 150px;
            width: 90px;
            left: 50%;
            margin-left: -45px;
            position: absolute;
            background: url(img/images/pointer.png) no-repeat center center;
            background-size: cover;
        }
        
        .intro-bg .pointer .cursor.c2
        {
            pointer-events: none;
            -webkit-transition: height ease 0.5s;
            -o-transition: height ease 0.5s;
            transition: height ease 0.5s;
            height: 0;
            width: 90px;
            background: url(img/images/pointer2.png) no-repeat top center;
            background-size: 90px 150px;
        }
        .intro-bg .pointer .c2.on
        {
            height: 150px;
        }
        .intro-bg .pointer .line
        {
            pointer-events: none;
            -webkit-animation: p-line 3s linear 2s infinite;
            -o-animation: p-line 3s linear 2s infinite;
            animation: p-line 3s linear 2s infinite;
            left: 0;
            position: absolute;
            width: 100%;
            height: 15px;
            background: url(img/images/line.png) no-repeat center center;
            background-size: contain;
        }
        .intro-bg .pointer:hover .line
        {
            left: -100%;
        }
    </style>
</head>
<body style="margin: 0px; padding: 0px; background-color: #fff">
    <audio id="bg-music" preload="preload" src="sound/fudan_bg.mp3" autoplay="autoplay"
        loop="loop"></audio>
    <div class="intro" style="background-color: black; height: 100%; width: 100%;">
        <div class="intro-bg">
            <div class="adver">
                <img src="img/images/adver.png" alt="">
                <img class="adver1" src="img/images/adver1.png" alt="">
            </div>
            <div class="pointer" pj-finger="" style="touch-action: pan-y; -webkit-user-select: none;
                -webkit-user-drag: none; -webkit-tap-highlight-color: rgba(0, 0, 0, 0);">
                <div class="cursor c1">
                </div>
                <div class="cursor c2">
                </div>
                <div class="line">
                </div>
            </div>
            <span class="font">录入指纹 开始探索</span>
        </div>
    </div>
    <div class="wrap" id="scene" style="display: none;">
        <div class="sec drag">
            <section class="sec01 pr">
                <div class="p1 cover "></div>
                <div class="p2 cover "></div>
                <div class="p3 cover "></div>
                <span class="start"><b></b></span>
            </section>
            <section class="sec02 pr">
                <div class="p1 cover "></div>
                <div class="p2 cover " id="test"></div>
                <div class="p3 cover " style="-webkit-transition: height ease 0.3s; -o-transition: height ease 0.3s;transition: height ease 0.3s;"></div>
                <span class="start"><b></b></span>
            </section>
            <section class="sec03 pr">
                <div class="p1 cover "></div>
                <div class="p2 cover "></div>
                <div class="p3 cover "></div>
                <span class="start"><b></b></span>
            </section>
            <section class="sec04 pr">
                <div class="title cover "></div>
                <div class="p2 cover "></div>
                <span class="start"><b></b></span>
            </section>
            <section class="sec05 pr">
                <div class="title cover "></div>
                <div class="p2 cover "></div>
                <div class="p3 cover "></div>
                <span class="start"><b></b></span>
            </section>
            <section class="sec06 pr">
                <div class="qr">
                    <div>
                        <img src="img/qr/qr1.jpg" alt="长按图片可以下载" />
                    </div>
                </div>
                <div class="p2">
                    <a href="http://www.mikecrm.com/f.php?t=XKGY39"><img src="img/p6_button.png" alt="跳转" /></a>
                </div>
            </section>
        </div>
        <div style="display: none">
        </div>
    </div>
    <dl class="bgsoundsw">
        <dt></dt>
        <dd>
        </dd>
    </dl>
    <script src="js/1.js?v=1" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            setTimeout(function () {
                setTimeout(function () {
                    $("#starfield").css("display", "none");
                    Star.end();
                    initPage();
                }, 200);
            });
        }, 200);

        var animationDiv = $(".sec05 .title");
        animationDiv.bind("webkitAnimationEnd", function () {
            setTimeout(function () {
                animationDiv.hide();
                var animationDiv2 = $(".sec05 .p2");
                animationDiv2.addClass("show");
                animationDiv2.bind("webkitAnimationEnd", function () {
                    setTimeout(function () {
                        animationDiv2.hide();
                        var animationDiv3 = $(".sec05 .p3");
                        animationDiv3.addClass("show");
                    }, 1000);
                });
            }, 1000);
        });

        $(window).load(function () {
            playMusic();
            //背景声音开关
            $(".bgsoundsw").on('touchstart', function (e) {
                if ($(this).children('dd').is(':hidden')) {
                    pauseMusic();
                } else {
                    playMusic();
                }
                $(this).children().toggle();
            });
        });
        var timer = null;
        var flag = false;
        $(".pointer .c1").on("touchstart", function () {
            $(".pointer .c2").addClass("on");
            timer = setTimeout(function () {
                flag = true; //触摸是否有效
                setTimeout(function () {
                    $("#scene").show();
                    $(".intro").hide();
                }, 1000);
            }, 300); //触摸计时开始
        });

        $(".pointer .c1").on("touchend", function () {
            if (!flag) {//触摸无效
                clearTimeout(timer);
                $(".pointer .c2").removeClass("on");
            }
        });
    </script>
</body>
</html>
