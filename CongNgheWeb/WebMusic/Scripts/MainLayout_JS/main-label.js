//slider detail-label-artist
function Artist_Label() {
    $(".detail-label-artist-pages-li").on("click", function () {
        var sttSelect = $(this).attr("stt");
        $(".detail-label-artist-pages-li").removeClass('detail-label-artist-pages-li-active');
        $(".detail-label-artist-pages-li").eq(sttSelect).addClass('detail-label-artist-pages-li-active');
        $(".detail-label-artist-info").hide();
        $(".detail-label-artist-info").eq(sttSelect).show();
    });
}
//END Slider-detail-label-artist