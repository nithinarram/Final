$(document).ready(function () {

    $("#menu-section, #nav-bar-item-menu").click(function (e) {
        e.preventDefault();
        $("html, body").animate({ scrollTop: 700 }, "slow");
    });

    $(document).scroll(function () {
        if ($(this).scrollTop() > 650) {
            $('#nav-bar-overlay').fadeIn(120);
        }

        if ($(this).scrollTop() < 650) {
            $('#nav-bar-overlay').fadeOut(120);
        }
    });

    $("#drinks-section, #nav-bar-item-drinks").click(function (e) {
        e.preventDefault();
        $("html, body").animate({ scrollTop: 2300 }, "slow");
    });

    $("#location-section").click(function (e) {
        e.preventDefault();
        $("html, body").animate({ scrollTop: 3361 }, 1250);
    });

    $("#nav-bar-item-top").click(function (e) {
        e.preventDefault();
        $("html, body").animate({ scrollTop: 0 }, 1250);
    });

    $("#contact-section, #nav-bar-item-contact").click(function (e) {
        e.preventDefault();
        $("html, body").animate({ scrollTop: 3361 }, 1250);
    });

    $('#reservation-button').click(function () {
        $("#dialog-box").fadeIn(150);
        $("#dialog-overlay").fadeIn(150);
    });

    $("#close-dialog-menu").click(function () {
        $("#dialog-box").fadeOut(150);
        $("#dialog-overlay").fadeOut(150);
    });

    $("#dialog-overlay").click(function () {
        $("#dialog-box").fadeOut(150);
        $("#dialog-overlay").fadeOut(150);
    });

    $("#dinner-menu-bar-text").click(function () {
        $(this).css("color", "#ff8b38");
        $("#when-available-dinner").css("color", "#ff8b38");

        $("#lunch-menu-bar-text").css("color", "#c9c9c9");
        $("#when-available-lunch").css("color", "#c9c9c9");

        $("#happy-hour-bar-text").css("color", "#c9c9c9");
        $("#when-available-happy").css("color", "#c9c9c9");
    });

    $("#happy-hour-bar-text").click(function () {
        $(this).css("color", "#ff8b38");
        $("#when-available-happy").css("color", "#ff8b38");

        $("#lunch-menu-bar-text").css("color", "#c9c9c9");
        $("#when-available-lunch").css("color", "#c9c9c9");

        $("#dinner-menu-bar-text").css("color", "#c9c9c9");
        $("#when-available-dinner").css("color", "#c9c9c9");
    });

    $("#lunch-menu-bar-text").click(function () {
        $(this).css("color", "#ff8b38");
        $("#when-available-lunch").css("color", "#ff8b38");

        $("#happy-hour-bar-text").css("color", "#c9c9c9");
        $("#when-available-happy").css("color", "#c9c9c9");

        $("#dinner-menu-bar-text").css("color", "#c9c9c9");
        $("#when-available-dinner").css("color", "#c9c9c9");
    });

});