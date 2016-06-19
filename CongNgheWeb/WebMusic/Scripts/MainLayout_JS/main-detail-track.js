
// #region SHORT STRING

function ShortStringTrack() {
    var stringFull = $("#short-text-content-track").text();

    function displayShortString() {
        var lenStringFull = 0;
        lenStringFull = $("#short-text-content-track").text().length;
        if (lenStringFull > 20) {
            $("#short-text-content-track").text($("#short-text-content-track").text().substr(0, 250) + '...');
        }
    }

    function displayMoreString() {
        $("#short-text-content-track").text(stringFull);
    }

    displayShortString();

    $(".short-text-content-track-more").click(function () {
        displayMoreString();
        $(this).hide();
        $(".short-text-content-track-less").show();
    });

    $(".short-text-content-track-less").click(function () {
        displayShortString();
        $(this).hide();
        $(".short-text-content-track-more").show();
    });

}

// #endregion




