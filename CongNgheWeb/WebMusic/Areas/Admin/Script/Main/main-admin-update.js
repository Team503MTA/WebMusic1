function updateClick(obj, type) {
    obj.style.color = '#777';
    obj.style.background = '#fbb';
}

function close_NotiForm() {
    $("#noti-form").hide();
    $(".extra").hide();
}

function noti_Fun(text, type) {
    $(".extra").show();
    document.getElementById("notiForm").innerHTML = text;
    if (type === "success") {
        document.getElementById("notiForm").style.background = '#0c0';
    } else {
        document.getElementById("notiForm").style.background = '#c00';
    }
    $("#noti-form").show();
}

function startLoad() {
    document.getElementById("loadProgress").classList.remove('endLoad');
    document.getElementById("loadProgress").className += 'loadingProgress';
}

function endLoad() {
    document.getElementById("loadProgress").classList.remove('loadingProgress');
    document.getElementById("loadProgress").className += 'endLoad';
}
