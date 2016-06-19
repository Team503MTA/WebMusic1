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





// #region SHORT STRING

function ShortStringLabel() {
    var stringFull = $("#detail-label-descrip-content").text();

    function displayShortString() {
        var lenStringFull = 0;
        lenStringFull = $("#detail-label-descrip-content").text().length;
        if (lenStringFull > 20) {
            $("#detail-label-descrip-content").text($("#detail-label-descrip-content").text().substr(0, 250) + '...');
        }
    }

    function displayMoreString() {
        $("#detail-label-descrip-content").text(stringFull);
    }

    displayShortString();

    $(".detail-label-more").click(function () {
        displayMoreString();
        $(this).hide();
        $(".detail-label-less").show();
    });

    $(".detail-label-less").click(function () {
        displayShortString();
        $(this).hide();
        $(".detail-label-more").show();
    });

}

// #endregion