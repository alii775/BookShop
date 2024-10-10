

var navBtn = document.getElementById("myNavBtn");
var desktopNav = document.getElementById("desktopNav");

navBtn.addEventListener("click" , () => {

    if(desktopNav.style.display === "flex"){
        desktopNav.style.display = "none";
    }
    else{
        desktopNav.style.display = "flex";
        desktopNav.style.flexDirection = "column"
    }
});







