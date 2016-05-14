////SLIDER CHART________________________________________________________________________________________________
$(document).ready(function () {
    var startimg = $(".slider-img:first").attr("stt");
    var endimg = $(".slider-img:last").attr("stt");
    var curli = $("slider-li-active").attr("stt");

    //SLIDER LI CLICK
    $(".slider-li").on("click", function () {
        curli = $(this).attr("stt");
        $(".slider-img-active").removeClass("slider-img-active");
        $(".slider-li-active").removeClass("slider-li-active");
        $(".slider-img").eq(curli).addClass("slider-img-active");
        $(".slider-li").eq(curli).addClass("slider-li-active");
    });

    //NEXT
    function next() {
        if (curli < endimg) {
            curli++;
        }
        else {
            curli = 0;
        }
        $(".slider-img-active").removeClass("slider-img-active");
        $(".slider-li-active").removeClass("slider-li-active");
        $(".slider-img").eq(curli).addClass("slider-img-active");
        $(".slider-li").eq(curli).addClass("slider-li-active");
    }

    //PREVIEW
    function prev() {
        if (curli > startimg) {
            curli--;
        }
        else {
            curli = endimg;
        }
        $(".slider-img-active").removeClass("slider-img-active");
        $(".slider-li-active").removeClass("slider-li-active");
        $(".slider-img").eq(curli).addClass("slider-img-active");
        $(".slider-li").eq(curli).addClass("slider-li-active");
    }
    var change = setInterval(next, 4000);
    $(".slider").on("mouseover", function () {
        $(".slider .direction").css("display", "inline-block");
        clearInterval(change);
    });
    $(".slider").on("mouseout", function () {
        $(".slider .direction").css("display", "none");
        change = setInterval(next, 4000);
    });
    $(".slider .prev").click(prev);
    $(".slider .next").click(next);
});

////NEW CHARTS_____________________________________________________________________________
/*   new charts   */
$(document).ready(function () {
    var startli = $(".new-charts-div:first").attr("stt");
    var endli = $(".new-charts-div:last").attr("stt");
    var curli = $(".new-charts-slider-li-active").attr("stt");

    //SLIDER LI CLICK
    $(".new-charts-slider-li").on("click", function () {
        curli = $(this).attr("stt");
        $(".new-charts-div-active").removeClass("new-charts-div-active");
        $(".new-charts-slider-li-active").removeClass("new-charts-slider-li-active");
        $(".new-charts-div").eq(curli).addClass("new-charts-div-active");
        $(".new-charts-slider-li").eq(curli).addClass("new-charts-slider-li-active");
        if (curli === endli) {
            $(".new-charts .direction .next .glyphicon").css("color", "#949494");
        } else {
            $(".new-charts .direction .next .glyphicon").css("color", "#fff");
        }
        if (curli === startli) {
            $(".new-charts .direction .prev .glyphicon").css("color", "#949494");
        } else {
            $(".new-charts .direction .prev .glyphicon").css("color", "#fff");
        }
    });

    //NEXT
    function nextChart() {
        var cur = $(".new-charts-slider-li-active").attr("stt");
        if (cur < endli) {
            $(".new-charts .direction .prev .glyphicon").css("color", "#fff");
            curli++;
            $(".new-charts-div-active").removeClass("new-charts-div-active");
            $(".new-charts-slider-li-active").removeClass("new-charts-slider-li-active");
            $(".new-charts-div").eq(cur).addClass("new-charts-div-active");
            $(".new-charts-slider-li").eq(cur).addClass("new-charts-slider-li-active");
        } else {
            $(".new-charts .direction .next").disable();
        }
    }

    //PREVIEW
    function prevChart() {
        var cur = $(".new-charts-slider-li-active").attr("stt");
        if (cur > startli) {
            $(".new-charts .direction .next").css("color", "#fff");
            cur--;
            $(".new-charts-div-active").removeClass("new-charts-div-active");
            $(".new-charts-slider-li-active").removeClass("new-charts-slider-li-active");
            $(".new-charts-div").eq(cur).addClass("new-charts-div-active");
            $(".new-charts-slider-li").eq(cur).addClass("new-charts-slider-li-active");
        } else {
            $(".new-charts .direction .prev").disable();
        }
    }
    $(".new-charts .direction .next").click(nextChart);
    $(".new-charts .direction .prev").click(prevChart);

    $(".new-charts .direction .next").click();
    $(".new-charts .direction .prev").click();
});

////CHART DETAIL___________________________________________________________________________
$(document).ready(function () {
    var tem = $("a#genre:last)").Text();
    tem = tem.substring(0, tem.length() - 2);
    $("a#genre:last").html(tem);

    $(".div-tracks-title span, .div-tracks-artist a").each(function () {
        var text = $(this).text();
        if (text.length > 35) {
            text = text.substring(0, 32) + "...";
            $(this).html(text);
        }
    });
});