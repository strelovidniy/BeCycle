$(document).ready(function () {

    if (window.location.href.includes('/editprofile')) {
        $(".sidebar-bottom").hide();
        $(".sidebar-mobile-bottom").hide();
    } else {
        $(".sidebar-bottom").show();
        $(".sidebar-mobile-bottom").show();
    }

    if(window.location.href.includes('/gojourney'))
    {
        var css_file = document.createElement("link");
        css_file.setAttribute("rel", "stylesheet");
        css_file.setAttribute("type", "text/css");
        css_file.setAttribute("href", 'https://s.bookcdn.com/css/w/booked-wzs-widget-160x275.css?v=0.0.1');
        document.getElementsByTagName("head")[0].appendChild(css_file);
        function setWidgetData(data) {
            if (typeof (data) != 'undefined' && data.results.length > 0) {
                for (var i = 0; i < data.results.length; ++i) {
                    var objMainBlock = document.getElementById('m-booked-bl-simple-week-vertical-95814');
                    if (objMainBlock !== null) {
                        var copyBlock = document.getElementById('m-bookew-weather-copy-' + data.results[i].widget_type);
                        objMainBlock.innerHTML = data.results[i].html_code;
                        if (copyBlock !== null) objMainBlock.appendChild(copyBlock);
                    }
                }
            } else {
                alert('data=undefined||data.results is empty');
            }
        }

        $(".weather").appendTo($(".sidebar"));
        $(".weather").css('display', 'block');
    }

    if (!window.matchMedia("(max-width: 767px)").matches) {
        $(".sidebar").css('display', 'flex');
        $(".editing-desktop").css('display', 'block');
        $(".editing-mobile").css('display', 'none');
    }

    if (window.matchMedia("(max-width: 767px)").matches) {
        $(".mobile-heading-edit").css('display', 'none');
        $(".editing-mobile").css('display', 'block');
        $(".editing-desktop").css('display', 'none');
    }


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
    $(".sidebar").css({ 'left': '0px' }).animate({
        'left': '-400px'
    });

    window.setTimeout(function () {
        document.location.href = home_url;
    }, 1000);
    
});

$(".option.map").click(function () {
    var map_url = $("#map-link").attr("href");
    $(".sidebar").css({ 'left': '0px' }).animate({
        'left': '-400px'
    });

    window.setTimeout(function () {
        document.location.href = map_url;
    }, 1000);
});

$(".option.poster-create").click(function () {
    var poster_url = $("#posterCreation-link").attr("href");
    $(".sidebar").css({ 'left': '0px' }).animate({
        'left': '-400px'
    });

    window.setTimeout(function () {
        document.location.href = poster_url;
    }, 1000);
});

$(".go-journey").click(function () {
    event.preventDefault();
    var goJourney_url = $("#GoJourney-link").attr("href");

    $(".sidebar").css({ 'left': '0px' }).animate({
        'left': '-400px'
    });

    window.setTimeout(function () {
        document.location.href = goJourney_url;
    }, 1000);
});

$(".profile-settings").click(function (event) {
    event.preventDefault();

    $(".sidebar").css({ 'left': '0px' }).animate({
        'left': '-400px'
    });

    window.setTimeout(function() {
        document.location.href = "/editprofile";
    }, 1000);

});

$(".profile-settings").hover(function () {
    $(this).css('cursor', 'pointer');
});

$("#view-profile-link").hover(function () {
    $(this).css('cursor', 'pointer');
});

$(".view-profile").click(function () {
    event.preventDefault();
    $(".sidebar").css({ 'left': '0px' }).animate({
        'left': '-400px'
    });


    window.setTimeout(function () {
        document.location.href = $("#view-profile-link").attr("href");
    }, 1000);
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