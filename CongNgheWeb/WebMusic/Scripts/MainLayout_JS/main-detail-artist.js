

// label descript
$(document).ready(function () {
    var string_detail_song_full = $("#detail-artist-descrip-content").text();

    function display_less_string_detail_song() {
        var len_descrip_song_detail = 0;
        len_descrip_song_detail = $("#detail-artist-descrip-content").text().length;
        if (len_descrip_song_detail > 40) {
            $("#detail-artist-descrip-content").text($("#detail-artist-descrip-content").text().substr(0, 350) + '...');
        }
    }

    function display_more_string_detail_song() {
        $("#detail-artist-descrip-content").text(string_detail_song_full);
    }

    display_less_string_detail_song();

    $(".detail-artist-more").click(function () {
        display_more_string_detail_song();
        $(this).hide();
        $(".detail-artist-less").show();
    });

    $(".detail-artist-less").click(function () {
        display_less_string_detail_song();
        $(this).hide();
        $(".detail-artist-more").show();
    });
});


//slider detail-label-artist
$(document).ready(function () {

    $(".detail-label-artist-pages-li").on("click", function () {
        var sttSelect = $(this).attr("stt");
        $(".detail-label-artist-pages-li").removeClass('detail-label-artist-pages-li-active');
        $(".detail-label-artist-pages-li").eq(sttSelect).addClass('detail-label-artist-pages-li-active');
        $(".detail-label-artist-info").hide();
        $(".detail-label-artist-info").eq(sttSelect).show();
    });
});
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