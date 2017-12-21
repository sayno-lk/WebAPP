function playMusic() {
    bgMusic.play(),
        bgMusic.paused || (playFlag = !0, firstTimePlay = !1);
}
function pauseMusic() {
    bgMusic.pause()
}
function musicOn() { musicTime = setInterval(function () { bgMusic.paused && bgMusic.play() }, 1e3) }
function musicStop() { clearInterval(musicTime) }
function initPage() {
    pageWidth = $(window).width() - 0, pageHeight = $(".wrap").height() - 0;
    pages = $(".wrap section"), $(".bg .bg_sec").css("height", pageHeight);
    $(".bg .bg_sec").height();
    $(".wrap section").css({ width: pageWidth + "px", height: pageHeight + "px" }),
             secHeight = pageHeight * $(".wrap section").length, lineHeight = 832 * secHeight / pageHeight, $(".sec").addClass("drag"),
             animatePage(curPage)
}
function orientationChange() { initPage() }
function onStart(t) {
    return 1 == movePrevent ? (event.preventDefault(), !1) : (touchDown = !0, startX = t.pageX,
        startY = t.pageY, $(".sec").addClass("drag"), margin = $(".sec").css("-webkit-transform"),
         margin = margin.replace("matrix(", ""), margin = margin.replace(")", ""), margin = margin.split(","),
         void (margin = parseInt(margin[5])))
}
function onMove(t) {
    //alert("d:" + car2._moveStart);
    if (1 != isNextPage) {
        return;
    }
    if (1 == movePrevent || 1 != touchDown) return event.preventDefault(), !1;
    if (event.preventDefault(), 0 == scrollPrevent && t.pageY != startY) { var e = margin + t.pageY - startY; $(".sec").css("-webkit-transform", "matrix(1, 0, 0, 1, 0, " + e + ")") }
}
function onEnd(t) {
    if (1 == movePrevent) return event.preventDefault(), !1;
    if (touchDown = !1, 0 == scrollPrevent) {
        endX = t.pageX; endY = t.pageY;
        Math.abs(endY - startY) <= 100 ? animatePage(curPage) : endY > startY ? prevPage() : nextPage();
    }
    $(".sec").removeClass("drag");
}
function prevPage() { var t = curPage - 1; animatePage(t) }
function nextPage() { var t = curPage + 1; animatePage(t) }
function animatePage(t) {
    if (1 != isNextPage) {
        return;
    }
    //alert("ing:"+t);
    $("#invite").css("display", "none"),
          $(".spop").removeClass("show"), 0 > t && (t = 0), t > $(".wrap section").length - 1 && (t = $(".wrap section").length - 1), curPage = t;
    var e = t * -pageHeight;
    $(".sec").css({ "-webkit-transform": "matrix(1, 0, 0, 1, 0, " + e + ")" }),
           movePrevent = !0, setTimeout("movePrevent=false;", 300),
           $(pages[curPage]).hasClass("page-show") || $(pages[curPage]).addClass("page-show"),
            $(pages[curPage - 1]).removeClass("page-show"),
            $(pages[curPage + 1]).removeClass("page-show")
    //alert("ing_end:" + t);
}
var stopend = 0, isinput = 0,
         TS = document.body.addEventListener("touchstart", function (t) {
             return firstTimePlay && playMusic(), stopend = 0, isinput ? !1 : (t = t.changedTouches[0], void onStart(t))
         }),
          TM = document.body.addEventListener("touchmove", function (t) {
              return stopend = 0, isinput || "slide" == t.target.id ? !1 : void onMove(t.changedTouches[0], t)
          }),
          TE = document.body.addEventListener("touchend", function (t) {
              // alert(t); $(".content").addClass("show");    
              if (!$("#j-mengban").hasClass("z-show") && car2._moveStart == false) {
                  car2._moveStart = true;
                  return;
              }
              if (!car2._moveStart) {
                  return;
              }
              return stopend || isinput ? !1 : "slide" == t.target.id ? (endX = t.changedTouches[0].pageX, stopend = 1, !1) : void onEnd(t.changedTouches[0])
          }),
           curAct = "";
window.onorientationchange = orientationChange;
var playFlag = 1, dragSpan = 0,
firstTimePlay = !0,
bgMusic = $("#bg-music")[0];
bgMusic.autoplay = !0,
bgMusic.loop = !0;
var musicTime = null, startX = 0, startY = 0; margin = 0; var pages = null, curPage = 0, pageWidth = 0, pageHeight = 0, lineHeight = 0, secHeight = 0,
             targetElement = null, scrollPrevent = !1, movePrevent = !1, touchDown = !1;
$(document).ready(function () {
    //$("#starfield").hide(), 
    //Star.start(),
    setTimeout(function () { //$("#starfield").show(), 
        //loadImg(pics, function () {
        setTimeout(function () {
            $("#starfield").css("display", "none"), Star.end(),
            playMusic(),
                initPage(),
            // 禁止滑动
                car2._moveStart = false;
        }, 200)
        //})
    });
}, 200),
        $(".nextPage").click(function () { nextPage() });