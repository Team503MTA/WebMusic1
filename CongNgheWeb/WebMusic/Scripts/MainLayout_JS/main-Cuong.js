// song detail
$(document).ready(function () {
    var string_Full = $("#decrib-detail-list-show").text();

    function Display_Short_String() {
        var len_String_Full = 0;
        len_String_Full = $("#decrib-detail-list-show").text().length;
        if (len_String_Full > 50) {
            $("#decrib-detail-list-show").text($("#decrib-detail-list-show").text().substr(0, 100) + '...');
        }
    }

    function Display_More_String() {
        $("#decrib-detail-list-show").text(string_Full);
    }

    Display_Short_String();

    $(".decrib-detail-list-show-more").click(function () {
        Display_More_String();
        $(this).hide();
        $(".decrib-detail-list-show-less").show();
    });

    $(".decrib-detail-list-show-less").click(function () {
        Display_Short_String();
        $(this).hide();
        $(".decrib-detail-list-show-more").show();
    });

});

// song detail slider show
$(document).ready(function () {
    var string_Full = $("#decrib-detail-slider-show").text();

    function Display_Short_String() {
        var len_String_Full = 0;
        len_String_Full = $("#decrib-detail-slider-show").text().length;
        if (len_String_Full > 50) {
            $("#decrib-detail-slider-show").text($("#decrib-detail-slider-show").text().substr(0, 100) + '...');
        }
    }

    function Display_More_String() {
        $("#decrib-detail-slider-show").text(string_Full);
    }

    Display_Short_String();

    $(".decrib-detail-slider-show-more").click(function () {
        Display_More_String();
        $(this).hide();
        $(".decrib-detail-slider-show-less").show();
    });

    $(".decrib-detail-slider-show-less").click(function () {
        Display_Short_String();
        $(this).hide();
        $(".decrib-detail-slider-show-more").show();
    });

});

// song detail slider listen
$(document).ready(function () {
    var string_Full = $("#detail-slider-listen").text();

    function Display_Short_String() {
        var len_String_Full = 0;
        len_String_Full = $("#detail-slider-listen").text().length;
        if (len_String_Full > 100) {
            $("#detail-slider-listen").text($("#detail-slider-listen").text().substr(0, 250) + '...');
        }
    }

    function Display_More_String() {
        $("#detail-slider-listen").text(string_Full);
    }

    Display_Short_String();

    $(".detail-slider-listen-more").click(function () {
        Display_More_String();
        $(this).hide();
        $(".detail-slider-listen-less").show();
    });

    $(".detail-slider-listen-less").click(function () {
        Display_Short_String();
        $(this).hide();
        $(".detail-slider-listen-more").show();
    });

});

//slider

$(document).ready(function () {

    var stt = 0;
    var firstImg = $(".slider-img:first").attr("stt");
    var endImg = $(".slider-img:last").attr("stt");

    $(".slider-img").each(function () {
        if ($(this).is(':visible')) {
            stt = $(this).attr("stt");
        }
    });

    function sliderNext() {
        stt++;
        if (stt > endImg) {
            stt = firstImg;
        }
        $(".slider-img").hide();
        $(".slider-img").eq(stt).show();
        $(".slider-button").removeClass("slider-button-active");
        $(".slider-button").eq(stt).addClass("slider-button-active");
    }

    function sliderPrev() {
        stt--;
        if (stt < firstImg) {
            stt = endImg;
        }
        $(".slider-img").hide();
        $(".slider-img").eq(stt).show();
        $(".slider-button").removeClass("slider-button-active");
        $(".slider-button").eq(stt).addClass("slider-button-active");
    }

    var interval_Slider = setInterval(function () {
        sliderNext();
    }, 3000);

    $(".slider-img").on("mouseover", function () {
        clearInterval(interval_Slider);
    });

    $(".slider-img").on("mouseout", function () {
        interval_Slider = setInterval(function () {
            sliderNext();
        }, 3000);
    });

    $(".slider-button").on("click", function () {

        var sttSelect = $(this).attr("stt");
        $(".slider-button").removeClass('slider-button-active');
        $(".slider-button").eq(sttSelect).addClass('slider-button-active');
        $(".slider-img").hide();
        $(".slider-img").eq(sttSelect).show();
        stt = sttSelect;
    });

});
//slider end

//login

$(document).ready(function () {
    $("#login-button").click(function () {
        $("#login-form").show();
    })

    $("#button-me-cancel").click(function () {
        $("#login-form").hide();
    })
});

$(document).ready(function () {
    var displaygenres = 0;
    $("#genres-button").click(function () {
        if (displaygenres == 0) {
            $("#genres-detail").show();
            $(this).css("background", "#eee");
            displaygenres = 1;
        } else {
            $("#genres-detail").hide();
            $(this).css("background", "transparent");
            displaygenres = 0;
        }
    })
});
//Regsite
$(document).ready(function(){
    $("#register-button").click(function(){
        $(".register-form").show();
        $(".extra").show();
    });
    $("#register-form-button-cancel").click(function(){
        $(".register-form").hide();
        $(".extra").hide();
    });
});



//End Regsite

/* genres */
$(document).ready(function () {
    var displaygenres = 0;
    $("#genres-button").click(function () {
        if (displaygenres == 0) {
            $(".genres-list").show();
            $(this).css("background", "#eee");
            displaygenres = 1;
        } else {
            $(".genres-list").hide();
            $(this).css("background", "transparent");
            displaygenres = 0;
        }
    })
});

//event tag play music

$(document).ready(function () {
    var playmusic = 0;
    var audio = document.getElementById('myTune');

    function ConvertTime(timeSecond) {
        var hour = 0;
        var minutes = 0;
        var second = 0;
        var stringTime = "";
        hour = Math.floor(timeSecond / 3600);
        timeSecond = timeSecond - hour * 3600;
        minutes = Math.floor(timeSecond / 60);
        timeSecond = timeSecond - minutes * 60;
        second = Math.floor(timeSecond);
        var correctSecond = "";
        if (second < 10) {
            correctSecond = "0" + second;
        } else {
            correctSecond = second;
        }
        if (hour == 0) {
            stringTime = minutes + ":" + correctSecond;
        } else {
            stringTime = hour + ":" + minutes + ":" + correctSecond;
        }
        return stringTime;
    }

    audio.addEventListener('loadedmetadata', function () {
        var lengaudio = parseInt(audio.duration);
        var lengaudioText = ConvertTime(lengaudio);
        document.getElementById("playmusic-end").innerHTML = lengaudioText;
        document.getElementById("playmusic-start").innerHTML = "0:00";
    });

    //event end audio
    audio.onended = function () {
        if (audio.loop == false) {
            PauseMusic();
        }
    };

    //function play music
    function PlayMusic() {
        audio.play();
        playmusic = 1;
        $("#playButton .glyphicon-play").hide();
        $("#playButton .glyphicon-pause").show();
    }

    //function pause music
    function PauseMusic() {
        audio.pause();
        playmusic = 0;
        $("#playButton .glyphicon-pause").hide();
        $("#playButton .glyphicon-play").show();
    }

    //event click loop
    $("#loopButton").click(function () {
        if (audio.loop == false) {
            if (playmusic == 0) {
                PlayMusic();
            }
            audio.loop = true;
            $("#loopButton").css("color", "#fff");
        } else {
            audio.loop = false;
            $("#loopButton").css("color", "#888");
        }

    });

    var intervalPlayMusic;
    //event click playmusic
    $("#playButton").click(function () {
        if (playmusic == 0) {
            PlayMusic();
            intervalPlayMusic = setInterval(function () {
                document.getElementById("playmusic-start").innerHTML = ConvertTime(parseInt(audio.currentTime));
                currentValuePlayMusic = (audio.currentTime / audio.duration) * 100;
                document.getElementById("playmusic-process").value = currentValuePlayMusic;
            }, 100);
        } else {
            PauseMusic();
            clearInterval(intervalPlayMusic);
        }
    });

    //event click fast forward music
    var PlaymusicLenPer;
    $("#playmusic-process").click(function (ev) {
        PlaymusicLenPer = $("#playmusic-process").width() / 100;
        var lenCurrent_playMusic = ev.clientX - $("#playmusic-process").offset().left;
        var Playmusic_currentPer = lenCurrent_playMusic / PlaymusicLenPer;

        document.getElementById("playmusic-process").value = Playmusic_currentPer;
        document.getElementById("myTune").currentTime = (Playmusic_currentPer / 100) * audio.duration;
        document.getElementById("playmusic-start").innerHTML = ConvertTime(audio.currentTime);
    });

    //volume in progress
    var volumeLenPer;
    $("#volumeProBar").click(function (ev_volume) {
        volumeLenPer = $("#volumeProBar").width() / 100;
        var lenCurrent_volume = ev_volume.clientX - $("#volumeProBar").offset().left;
        document.getElementById("volumeProBar").value = lenCurrent_volume / volumeLenPer;
        document.getElementById("myTune").volume = document.getElementById("volumeProBar").value / 100;
        if (audio.volume < 0.5) {
            $("#volume .glyphicon-volume-down").show();
            $("#volume .glyphicon-volume-up").hide();
        } else {
            $("#volume .glyphicon-volume-down").hide();
            $("#volume .glyphicon-volume-up").show();
        }
    });

    //volume in icon
    var oldVolume;
    var oldVolumeLength;
    $("#volumeButton").click(function () {
        if (audio.volume > 0) {
            oldVolume = audio.volume;
            oldVolumeLength = document.getElementById("volumeProBar").value;
            document.getElementById("myTune").volume = 0;
            document.getElementById("volumeProBar").value = 0;
            $("#volume .glyphicon-volume-down").hide();
            $("#volume .glyphicon-volume-up").hide();
            $("#volume .glyphicon-volume-off").show();
        } else {
            document.getElementById("myTune").volume = oldVolume;
            document.getElementById("volumeProBar").value = oldVolumeLength;
            $("#volume .glyphicon-volume-off").hide();
            if (audio.volume < 0.5) {
                $("#volume .glyphicon-volume-down").show();
            } else {
                $("#volume .glyphicon-volume-up").show();
            }
        }

    });


});
// top video
$(document).ready(function(){
    var stt = 1; 
    $(".video").hover(function(){
        stt = $(this).attr('stt');
        $(".video a i").eq(stt).show();
        $(".video a div").eq(stt).show();
    });
    
    $(".video").mouseleave(function(){
        $(".video a i").eq(stt).hide();
        $(".video a div").eq(stt).hide();
    });
});
// new on beat
$(document).ready(function(){
    var stt = 1; 
    $(".newvideo").hover(function(){
        stt = $(this).attr('stt');
        $(".newvideo a i").eq(stt).show();
        $(".newvideo a div").eq(stt).show();
    });
    
    $(".newvideo").mouseleave(function(){
        $(".newvideo a i").eq(stt).hide();
        $(".newvideo a div").eq(stt).hide();
    });
});


//staff picks video//
$(document).ready(function(){
    var stt = 1; 
    $(".staff-video").hover(function(){
        stt = $(this).attr('stt');
        $(".staff-video a i").eq(stt).show();
        $(".staff-video a div").eq(stt).show();
    });
    
    $(".staff-video").mouseleave(function(){
        $(".staff-video a i").eq(stt).hide();
        $(".staff-video a div").eq(stt).hide();
    });
});




$(document).ready(function () {
//    var stt = 1;
    firstImg = $(".slider-img:first").attr("stt");
    endImg = $(".slider-img:last").attr("stt");
    $(".slider-img").each(function () {
        if ($(this).is(':visible')) {
            stt = $(this).attr("stt");
        }
    });

    function sliderNext() {
        stt++;
        if (stt > endImg) {
            stt = firstImg;
        }
        $(".slider-img").hide();
        $(".slider-img").eq(stt).show();
    }

    function sliderPrev() {
        stt--;
        if (stt < firstImg) {
            stt = endImg;
        }
        $(".slider-img").hide();
        $(".slider-img").eq(stt).show();
    }

    intervalID = setInterval(function () {
        sliderNext();
    }, 3000);

    $(".slider-img").on("mouseover", function () {
        clearInterval(intervalID);
    });

    $(".slider-img").on("mouseout", function () {
        intervalID = setInterval(function () {
            sliderNext();
        }, 3000);
    });

    $(".slider-next").on("click", function () {
        sliderNext();
    });
    
    $(".slider-prev").on("click", function () {
        sliderPrev();
    });
});


