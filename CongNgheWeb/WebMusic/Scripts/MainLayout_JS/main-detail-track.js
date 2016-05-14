// slider-detail-song-artist
$(document).ready(function () {

    $(".detail-song-artist-button").on("click", function () {
        var detail_song_artist_stt_select = $(this).attr("stt");
        $(".detail-song-artist-button").removeClass('detail-song-artist-button-active');
        $(".detail-song-artist-button").eq(detail_song_artist_stt_select).addClass('detail-song-artist-button-active');
        $(".slider-detail-song-artist-img").hide();
        $(".slider-detail-song-artist-img").eq(detail_song_artist_stt_select).show();
    });
});
// end slider-detail-song-artist




//slider-detail-song-label
$(document).ready(function () {

    $(".slider-detail-song-label-button").on("click", function () {
        var detail_song_label_stt_select = $(this).attr("stt");
        $(".slider-detail-song-label-button").removeClass('slider-detail-song-label-button-active');
        $(".slider-detail-song-label-button").eq(detail_song_label_stt_select).addClass('slider-detail-song-label-button-active');
        $(".slider-detail-song-label-img").hide();
        $(".slider-detail-song-label-img").eq(detail_song_label_stt_select).show();
    });
});
// end slider-detail-song-label




