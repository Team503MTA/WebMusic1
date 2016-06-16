


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

// #region SHORT STRING

function ShortString() {
    var stringFull = $("#short-text-content-artist").text();

    function displayShortString() {
        var lenStringFull = 0;
        lenStringFull = $("#short-text-content-artist").text().length;
        if (lenStringFull > 20) {
            $("#short-text-content-artist").text($("#short-text-content-artist").text().substr(0, 250) + '...');
        }
    }

    function displayMoreString() {
        $("#short-text-content-artist").text(stringFull);
    }

    displayShortString();

    $(".short-text-content-artist-more").click(function () {
        displayMoreString();
        $(this).hide();
        $(".short-text-content-artist-less").show();
    });

    $(".short-text-content-artist-less").click(function () {
        displayShortString();
        $(this).hide();
        $(".short-text-content-artist-more").show();
    });

}

// #endregion