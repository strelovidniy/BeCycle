$(document).ready(function () {
    $(".sidebar").css('display', 'flex');
    $(".sidebar").css({ 'left': '-400px' }).animate({
        'left': '-0px'
    });
});




// Sidebar
$(".option").hover(function () {
    $(this).css('cursor', 'pointer');
});

// Redirecting
$(".option.home").click(function () {
    var home_url = $("#home-link").attr("href");
    document.location.href = home_url;
});

$(".option.map").click(function () {
    var map_url = $("#map-link").attr("href");
    document.location.href = map_url;
});

$(".option.poster-create").click(function () {
    var poster_url = $("#posterCreation-link").attr("href");
    document.location.href = poster_url;
});

$(".option.poster-create").click(function () {
    var goJourney_url = $("#GoJourney").attr("href");
    document.location.href = goJourney_url;
});

$(".option.search").click(function () {
    var search_url = $("#search-link").attr("href");
    document.location.href = search_url;
});

$(".profile-settings").click(function () {
    $(".sidebar").css({ 'left': '0px' }).animate({
        'left': '-400px'
    });

    window.setTimeout(function() {
        document.location.href = "editprofile";
    }, 1000);

});

$(".profile-settings").hover(function () {
    $(this).css('cursor', 'pointer');
});

// Active tab
$(".active").hover(function () {
    $(this).css('background-color', "rgba(255, 255, 255, .3)");
});

$('.option').click(function (e) {
    $('.option').removeClass('active');

    var $this = $(this);
    if (!$this.hadClass('active')) {
        $this.addClass('active');
    }
});

$(".settings").mouseover(function() {
    $(this).css('transform', 'rotate(180deg)');
});

$(".settings").mouseleave(function () {
    $(this).css('transform', 'rotate(-180deg)');
});


// Mobile Nav
$(".hamburger-menu").click(function() {
    $(".sidebar-mobile").css('left', '0');
});

$(".close-menu").click(function() {
    $(".sidebar-mobile").css('left', '-400px');
});