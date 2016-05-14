

// short string
$(document).ready(function () {
    var string_Full = $("#detail-label-descrip-content").text();

    function Display_Short_String() {
        var len_String_Full = 0;
        len_String_Full = $("#detail-label-descrip-content").text().length;
        if (len_String_Full > 20) {
            $("#detail-label-descrip-content").text($("#detail-label-descrip-content").text().substr(0, 250) + '...');
        }
    }

    function Display_More_String() {
        $("#detail-label-descrip-content").text(string_Full);
    }

    Display_Short_String();

    $(".detail-label-more").click(function () {
        Display_More_String();
        $(this).hide();
        $(".detail-label-less").show();
    });

    $(".detail-label-less").click(function () {
        Display_Short_String();
        $(this).hide();
        $(".detail-label-more").show();
    });

});
// end short string


//show this artist from label
$(document).ready(function () {

    $(".detail-label-artist-info").each(function () {
        if ($(this).attr("stt") === "0") {
            $(this).css("display", "inline-block");
        }
    });
});


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


