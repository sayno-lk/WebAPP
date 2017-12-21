var bgMusic = $("#bg-music")[0];
bgMusic.autoplay = !0;
bgMusic.loop = !0;
function playMusic() {
    bgMusic.play();
}
function pauseMusic() {
    bgMusic.pause();
}
$(window).load(function () {
    //playMusic();
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