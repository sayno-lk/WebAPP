function playMusic() {
    bgMusic.play()
}
function pauseMusic() {
    bgMusic.pause()
}
function initPage() {
    pageWidth = $(window).width() - 0,
	pageHeight = $(".wrap").height() - 0;
    pages = $(".wrap section"),
	$(".bg .bg_sec").css("height", pageHeight);
    $(".bg .bg_sec").height();
    $(".wrap section").css({
        width: pageWidth + "px",
        height: pageHeight + "px"
    }),
        secHeight = pageHeight * $(".wrap section").length,
        lineHeight = 832 * secHeight / pageHeight,
        $(".sec").addClass("drag"),
	animatePage(curPage)
}
function orientationChange() {
    initPage()
}
function onStart(t) {
    return 1 == movePrevent ? (event.preventDefault(), !1) : (touchDown = !0, startX = t.pageX, startY = t.pageY, $(".sec").addClass("drag"), margin = $(".sec").css("-webkit-transform"), margin = margin.replace("matrix(", ""), margin = margin.replace(")", ""), margin = margin.split(","), void (margin = parseInt(margin[5])))
}
function onMove(t) {
    //alert(curPage);
    if (curPage == 1) {
        //alert(movePrevent);
        //movePrevent = 1;
    }
    //alert("dd");
    if (1 == movePrevent || 1 != touchDown) return event.preventDefault(), !1;
    if (event.preventDefault(), 0 == scrollPrevent && t.pageY != startY) {
        var e = margin + t.pageY - startY;
        $(".sec").css("-webkit-transform", "matrix(1, 0, 0, 1, 0, " + e + ")")
    }
}
function onEnd(t) {

    if (1 == movePrevent) return event.preventDefault(), !1;
    if (touchDown = !1, 0 == scrollPrevent) {
        //alert("begin:" + curPage);
        endX = t.pageX,
		endY = t.pageY;
        //        if (curPage == 1) {
        //            Math.abs(endY - startY) <= 50 ? animatePage(curPage) : endY > startY ? prevPage() : animatePage(curPage);
        //        } else {
        //            Math.abs(endY - startY) <= 50 ? animatePage(curPage) : endY > startY ? prevPage() : nextPage();
        //        }
        Math.abs(endY - startY) <= 50 ? animatePage(curPage) : endY > startY ? prevPage() : nextPage();
        //alert("end:" + curPage);
    }
    $(".sec").removeClass("drag")
}
function prevPage() {
    var t = curPage - 1;
    animatePage(t)
}
function nextPage() {
    var t = curPage + 1;
    animatePage(t)
}
var nowL = 0;
var nowT = 0;
var minL = 0;
var minT = 0;
function initMyTouch(id) {
    var contentList = $("#" + id);
    contentList.css("left", 0);
    contentList.css("top", 0);
    nowL = 0;
    nowT = 0;
    var clientWidth = contentList.parent().width();
    minL = clientWidth - contentList.width();
}
function animatePage(t) {
    $("#invite").css("display", "none"),
	$(".spop").removeClass("show"),
	0 > t && (t = 0),
	t > $(".wrap section").length - 1 && (t = $(".wrap section").length - 1),
	curPage = t;
    var e = t * -pageHeight;
    $(".sec").css({
        "-webkit-transform": "matrix(1, 0, 0, 1, 0, " + e + ")"
    }),
	movePrevent = !0,
	setTimeout("movePrevent=false;", 300),
	$(pages[curPage]).hasClass("page-show") || $(pages[curPage]).addClass("page-show"),
	$(pages[curPage - 1]).removeClass("page-show"),
	$(pages[curPage + 1]).removeClass("page-show")
    //alert("ing_end:" + t);
}
var 
stopend = 0,
isinput = 0,
TS = document.body.addEventListener("touchstart",
function (t) {
    return firstTimePlay && playMusic(),
    stopend = 0,
	isinput ? !1 : (t = t.changedTouches[0], void onStart(t))
}),
TM = document.body.addEventListener("touchmove",
function (t) {
    return stopend = 0,
	isinput || "slide" == t.target.id ? !1 : void onMove(t.changedTouches[0], t)
}),
TE = document.body.addEventListener("touchend",
function (t) {
    // alert(t); $(".content").addClass("show");
    return stopend || isinput ? !1 : "slide" == t.target.id ? (endX = t.changedTouches[0].pageX, endX > startX ? ($(".tabsh").removeClass("show"), $(".txtsh").removeClass("show"), $(".clkbj").removeClass("show"), $(".content").addClass("show"), $(".tabbj").addClass("show"), $(".txtbj").addClass("show"), $(".clksh").addClass("show"), $(".sec06 .start").removeClass("show")) : ($(".tabbj").removeClass("show"), $(".txtbj").removeClass("show"), $(".clksh").removeClass("show"), $(".tabsh").addClass("show"), $(".txtsh").addClass("show"), $(".clkbj").addClass("show"), $(".sec06 .start").addClass("show")), stopend = 1, !1) : void onEnd(t.changedTouches[0])
});
window.onorientationchange = orientationChange;
var dragSpan = 0,
firstTimePlay = !0,
bgMusic = $("#bg-music")[0];
bgMusic.autoplay = !0,
bgMusic.loop = !0;
var musicTime = null,
startX = 0,
startY = 0;
margin = 0;
var pages = null,
curPage = 0,
pageWidth = 0,
pageHeight = 0,
lineHeight = 0,
secHeight = 0,
targetElement = null,
scrollPrevent = !1,
movePrevent = !1,
touchDown = !1;

//$(".nextPage").click(function () {
//    nextPage()
//});