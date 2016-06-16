


//slider detail-label-artist
function detail_Hot_Track_Label() {
    $(".detail-artist-trackLabel-slider-button").on("click", function () {
        var sttSelect = $(this).attr("stt");
        $(".detail-artist-trackLabel-slider-button").removeClass('detail-artist-trackLabel-slider-button-active');
        $(".detail-artist-trackLabel-slider-button").eq(sttSelect).addClass('detail-artist-trackLabel-slider-button-active');
        $(".detail-artist-trackLabel-slide").hide();
        $(".detail-artist-trackLabel-slide").eq(sttSelect).show();
    });
}
//END Slider-detail-label-artist



//slider detail-label-track
$(document).ready(function () {

    $(".detail-label-track-button").on("click", function () {
        var sttSelect = $(this).attr("stt");
        $(".detail-label-track-button").removeClass('detail-label-track-button-active');
        $(".detail-label-track-button").eq(sttSelect).addClass('detail-label-track-button-active');
        $(".detail-label-track-slide").hide();
        $(".detail-label-track-slide").eq(sttSelect).show();
    });
});

//END Slider-detail-label-track