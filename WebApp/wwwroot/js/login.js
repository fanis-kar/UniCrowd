window.onload = function () {
    "use strict";

    window.localStorage.removeItem("auth");

    function login() {
        const user = {
            "username": document.getElementById("username").value,
            "password": document.getElementById("password").value
        };

        common.post(settings.uri + "authentication/login", function (token)
        {
            const auth = {
                "username": user.username,
                "token": token
            };

            window.localStorage.setItem("auth", JSON.stringify(auth));
            window.location = "/Admin";
        }, function () {
            alert("Wrong credentials.");
        }, user);
    };

    document.getElementById("login").onclick = function ()
    {
        login();
    };

    document.getElementById("password").onkeyup = function (e)
    {
        if (e.keyCode === 13) {
            login();
        }
    };

    document.getElementById("register").onclick = function ()
    {
        window.location = "/register.html";
    };
};