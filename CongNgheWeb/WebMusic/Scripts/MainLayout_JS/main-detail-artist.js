
// #region SHORT STRING

function ShortStringArtist() {
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