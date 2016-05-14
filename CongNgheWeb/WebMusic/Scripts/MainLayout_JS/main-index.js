



// #region HOT-SLIDER

function hotSlider_Fun () {

    var stt_Hot_slider = 0;
    var firstImg_HotSlider = parseInt($(".hot-slider-img:first").attr("stt"));
    var endImg_HotSlider = parseInt($(".hot-slider-img:last").attr("stt"));

    $(".hot-slider-img").each(function () {
        if ($(this).is(':visible')) {
            stt_Hot_slider = $(this).attr("stt");
        }
    });

    function sliderNext() {
        stt_Hot_slider++;
        if (stt_Hot_slider > endImg_HotSlider) {
            stt_Hot_slider = firstImg_HotSlider;
        }
        $(".hot-slider-img").hide();
        $(".hot-slider-img").eq(stt_Hot_slider).show();
        $(".hot-slider-button").removeClass("hot-slider-button-active");
        $(".hot-slider-button").eq(stt_Hot_slider).addClass("hot-slider-button-active");
    }

    function sliderPrev() {
        stt_Hot_slider--;
        if (stt_Hot_slider < firstImg_HotSlider) {
            stt_Hot_slider = endImg_HotSlider;
        }
        $(".hot-slider-img").hide();
        $(".hot-slider-img").eq(stt_Hot_slider).show();
        $(".hot-slider-button").removeClass("hot-slider-button-active");
        $(".hot-slider-button").eq(stt_Hot_slider).addClass("hot-slider-button-active");
    }

    var interval_Slider = setInterval(function () {
        sliderNext();
    }, 3000);

    $(".hot-slider-img").on("mouseover", function () {
        clearInterval(interval_Slider);
    });

    $(".hot-slider-img").on("mouseout", function () {
        interval_Slider = setInterval(function () {
            sliderNext();
        }, 3000);
    });

    $(".hot-slider-button").on("click", function () {

        var stt_Hot_Slider_Select = $(this).attr("stt");
        $(".hot-slider-button").removeClass('hot-slider-button-active');
        $(".hot-slider-button").eq(stt_Hot_Slider_Select).addClass('hot-slider-button-active');
        $(".hot-slider-img").hide();
        $(".hot-slider-img").eq(stt_Hot_Slider_Select).show();
        stt_Hot_slider = stt_Hot_Slider_Select;
    });

}

// #endregion

// #region TOP-6-DJ

function Top_6_DJ_Fun() {
    $(".top-6-dj-button").on("click", function () {
        var stt_Top_6_DJ = $(this).attr("stt");
        $(".top-6-dj-child").hide();
        $(".top-6-dj-child").eq(stt_Top_6_DJ).show();
        $(".top-6-dj-button").removeClass('top-6-dj-button-active');
        $(".top-6-dj-button").eq(stt_Top_6_DJ).addClass('top-6-dj-button-active');
    });
}

// #endregion

// #region new track

function newTrack_Index_Fun() {
    $(".new-tracks-pages-li").on("click", function () {
        var stt = $(this).attr("stt");
        $(".new-track-div").hide();
        $(".new-track-div").eq(stt).show();
        $(".new-tracks-pages-li").removeClass('new-tracks-pages-li-active');
        $(".new-tracks-pages-li").eq(stt).addClass('new-tracks-pages-li-active');
    });
}

// #endregion

//hot remix
$(document).ready(function () {
    $(".hot-remix-pages-li").on("click", function () {
        var stt = $(this).attr("stt");
        $(".hot-remix-div").hide();
        $(".hot-remix-div").eq(stt).show();
        $(".hot-remix-pages-li").removeClass('hot-remix-pages-li-active');
        $(".hot-remix-pages-li").eq(stt).addClass('hot-remix-pages-li-active');
    });
});

//top-liveset
$(document).ready(function () {
    $(".live-set-slider-div").on("click", function () {
        var stt = $(this).attr("stt");
        $(".live-set-content-div").hide();
        $(".live-set-content-div").eq(stt).show();
        $(".live-set-slider-div").removeClass('live-set-slider-div-active');
        $(".live-set-slider-div").eq(stt).addClass('live-set-slider-div-active');
    });
});

//bucket
$(document).ready(function () {
    $(".bucket-pages-li").on("click", function () {
        var stt = $(this).attr("stt");
        $(".bucket-img").hide();
        $(".bucket-img").eq(stt).show();
        $(".bucket-pages-li").removeClass('bucket-pages-li-active');
        $(".bucket-pages-li").eq(stt).addClass('bucket-pages-li-active');
    });
});