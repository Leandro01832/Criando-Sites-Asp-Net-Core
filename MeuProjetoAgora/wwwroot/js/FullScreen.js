var elem = document.getElementById("corpoPagina");
var elem2 = document.getElementById("ConteudoPagina");
var elem3 = document.getElementById("LinhaImaginaria");

function openFullscreen() {
    if (elem.requestFullscreen) {
        elem.requestFullscreen();
    } else if (elem.mozRequestFullScreen) { /* Firefox */
        elem.mozRequestFullScreen();
    } else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
        elem.webkitRequestFullscreen();
    } else if (elem.msRequestFullscreen) { /* IE/Edge */
        elem.msRequestFullscreen();
    }
}

function openFullscreen2() {
    if (elem2.requestFullscreen) {
        elem2.requestFullscreen();
    } else if (elem2.mozRequestFullScreen) { /* Firefox */
        elem2.mozRequestFullScreen();
    } else if (elem2.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
        elem2.webkitRequestFullscreen();
    } else if (elem2.msRequestFullscreen) { /* IE/Edge */
        elem2.msRequestFullscreen();
    }



}

function openFullscreen3() {
    if (elem3.requestFullscreen) {
        elem3.requestFullscreen();
    } else if (elem3.mozRequestFullScreen) { /* Firefox */
        elem3.mozRequestFullScreen();
    } else if (elem3.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
        elem3.webkitRequestFullscreen();
    } else if (elem3.msRequestFullscreen) { /* IE/Edge */
        elem3.msRequestFullscreen();
    }
}