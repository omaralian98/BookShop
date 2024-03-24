window.onload = () => {
    sessionStorage.setItem("sidebar", "true");
}
function StateChange() {
    if (sessionStorage.getItem("sidebar") == "true")
        sessionStorage.setItem("sidebar", "false");
    else 
        sessionStorage.setItem("sidebar", "true");
}