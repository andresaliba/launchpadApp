function startAutoLogout() {
    // setup timeout that will occur when session has expired (20 minutes = 60000 * 20 milliseconds)
    window.setTimeout(() => document.location = "/", 1200000);
    // window.setTimeout(() => document.location = "/", 10000);
    // setup timeout that will occur after 18 minutes to warn the user
    window.setTimeout(() => document.getElementById("lblExpire").innerHTML = "WARNING : Session is about to expire!", 1080000);
    // window.setTimeout(() => document.getElementById("lblExpire").innerHTML = "WARNING : Session is about to expire!", 5000);
}