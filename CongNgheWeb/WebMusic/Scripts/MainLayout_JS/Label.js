

//.detail-label-artist-pages
$(document).ready(function () {

    $(".detail-label-artist-pages-li").on("click", function () {
        var sttSelect = $(this).attr("stt");
        $(".detail-label-artist-pages-li").removeClass('detail-label-artist-pages-li-active');
        $(".detail-label-artist-pages-li").eq(sttSelect).addClass('detail-label-artist-pages-li-active');
        $(".detail-label-artist-info").hide();
        $(".detail-label-artist-info").eq(sttSelect).show();
    });
});
//END .detail-label-artist-pages


//.detail-label-track-button
$(document).ready(function () {

    $(".detail-label-track-button").on("click", function () {
        var sttSelect = $(this).attr("stt");
        $(".detail-label-track-button").removeClass('detail-label-track-button-active');
        $(".detail-label-track-button").eq(sttSelect).addClass('detail-label-track-button-active');
        $(".detail-label-track-slide").hide();
        $(".detail-label-track-slide").eq(sttSelect).show();
    });
});
//END .detail-label-track-button


