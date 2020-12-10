$(document).ready(function () {

    // Current tab
    if (window.location.href.includes('/home')) {
        $('.home').addClass('active');
        $('.map').removeClass('active');
        $('.poster-create').removeClass('active');
        $('.go-journey').removeClass('active');
        $('.achivements').removeClass('active');
    }

    if (window.location.href.includes('/map')) {
        $('.map').addClass('active');
        $('.home').removeClass('active');
        $('.poster-create').removeClass('active');
        $('.go-journey').removeClass('active');
        $('.achivements').removeClass('active');
    }

    if (window.location.href.includes('/postercreation')) {
        $('.poster-create').addClass('active');
        $('.map').removeClass('active');
        $('.home').removeClass('active');
        $('.go-journey').removeClass('active');
        $('.achivements').removeClass('active');
    }

    if (window.location.href.includes('/gojourney')) {
        $('.go-journey').addClass('active');
        $('.map').removeClass('active');
        $('.poster-create').removeClass('active');
        $('.home').removeClass('active');
        $('.achivements').removeClass('active');
    }
    
    if (window.location.href.includes('/profile/achievements')) {
        $('.achivements').addClass('active');
        $('.map').removeClass('active');
        $('.poster-create').removeClass('active');
        $('.home').removeClass('active');
        $('.go-journey').removeClass('active');
    }



    if (window.location.href.includes('/editprofile')) {
        $(".sidebar-bottom").hide();
        $(".sidebar-mobile-bottom").hide();
    } else {
        $(".sidebar-bottom").show();
        $(".sidebar-mobile-bottom").show();
    }
   

    if (!window.matchMedia("(max-width: 767px)").matches) {
        $(".sidebar").css('display', 'flex');
        $(".editing-desktop").css('display', 'flex');
        $('#cursor').show();
        $('#aura').show();
        $(".editing-mobile").css('display', 'none');
    }

    if (window.matchMedia("(max-width: 767px)").matches) {
        $(".mobile-heading-edit").css('display', 'none');
        $(".editing-mobile").css('display', 'block');
        $('#cursor').hide();
        $('#aura').hide();
        $(".editing-desktop").css('display', 'none');

        $('#poster-description').attr('cols', '35');
    }


    $(".sidebar").css({ 'left': '-400px' }).animate({
        'left': '-0px'
    });
});




// Sidebar

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

$(".achivements").click(function () {
    var achivements_url = $("#achivements-link").attr("href");
    $(".sidebar").css({ 'left': '0px' }).animate({
        'left': '-400px'
    });

    window.setTimeout(function () {
        document.location.href = achivements_url;
    }, 1000);
});

$(".subscriptions").click(function () {
    var subscriptions_url = $("#subscriptions-link").attr("href");
    $(".sidebar").css({ 'left': '0px' }).animate({
        'left': '-400px'
    });

    window.setTimeout(function () {
        document.location.href = subscriptions_url;
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


$(".login-button").click(function () {

    document.location.href = '/account/google-signin';
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

$(document).ready(function () {
    var cursor = $('#cursor');
    var follower = $('#aura');


    $(window).mousemove(function (e) {
        cursor.css({
            top: (e.clientY - cursor.height() / 2) + 1,
            left: (e.clientX - cursor.width() / 2) + 1
        });
        follower.css({
            top: e.clientY - follower.height() / 2,
            left: e.clientX - follower.width() / 2
        })
    });

    $(window).mouseleave(function () {
        $(cursor).css('opacity', '0');
        $(follower).css('opacity', '0');
    });

    $(window).mouseenter(function () {
        $(cursor).css('opacity', '1');
        $(follower).css('opacity', '1');
    });

    $(window).click(function () {
        $(follower).addClass('auraAnimationClick')
        setTimeout(function () {
            $(follower).removeClass('auraAnimationClick')
        }, 1000);
    });

    $('.option').mouseenter(function () {
        $(follower).css({
            transform: "scale(1.1)",
            'background-color': "rgba(0,0,0,.005)"
        });
    });

    $('.option').mouseleave(function () {
        $(follower).css({
            transform: "scale(1)",
            'background-color': "rgba(255,255,255,.027)"
        });
    });

    $('.profile-settings').mouseenter(function () {
        $(follower).css({
            transform: "scale(1.1)",
            'background-color': "rgba(0,0,0,.005)"
        });
    });

    $('.profile-settings').mouseleave(function () {
        $(follower).css({
            transform: "scale(1)",
            'background-color': "rgba(255,255,255,.027)"
        });
    });



    $('.poster-title').mouseenter(function () {
        $(follower).css({
            transform: "scale(1.1)",
            'background-color': "rgba(0,0,0,.005)"
        });
    });

    $('.poster-title').mouseleave(function () {
        $(follower).css({
            transform: "scale(1)",
            'background-color': "rgba(255,255,255,.027)"
        });
    });


    $('.poster-description').mouseenter(function () {
        $(follower).css({
            transform: "scale(1.1)",
            'background-color': "rgba(0,0,0,.005)"
        });
    });

    $('.poster-description').mouseleave(function () {
        $(follower).css({
            transform: "scale(1)",
            'background-color': "rgba(255,255,255,.027)"
        });
    });

    $('.login-button').mouseenter(function () {
        $(follower).css({
            transform: "scale(1.1)",
            'background-color': "rgba(0,0,0,.005)"
        });
    });

    $('.login-button').mouseleave(function () {
        $(follower).css({
            transform: "scale(1)",
            'background-color': "rgba(255,255,255,.027)"
        });
    });

    $('.poster-date').mouseenter(function () {
        $(follower).css({
            transform: "scale(1.1)",
            'background-color': "rgba(0,0,0,.005)"
        });
    });

    $('.poster-date').mouseleave(function () {
        $(follower).css({
            transform: "scale(1)",
            'background-color': "rgba(255,255,255,.027)"
        });
    });

    $('.poster-type').mouseenter(function () {
        $(follower).css({
            transform: "scale(1.1)",
            'background-color': "rgba(0,0,0,.005)"
        });
    });

    $('.poster-type').mouseleave(function () {
        $(follower).css({
            transform: "scale(1)",
            'background-color': "rgba(255,255,255,.027)"
        });
    });


    $('#view-profile-link').mouseenter(function () {
        $(follower).css({
            transform: "scale(1.1)",
            'background-color': "rgba(0,0,0,.005)"
        });
    });

    $('#view-profile-link').mouseleave(function () {
        $(follower).css({
            transform: "scale(1)",
            'background-color': "rgba(255,255,255,.027)"
        });
    });

    $('button').mouseenter(function () {
        $(follower).css({
            transform: "scale(1.1)",
            'background-color': "rgba(0,0,0,.005)"
        });
    });

    $('button').mouseleave(function () {
        $(follower).css({
            transform: "scale(1)",
            'background-color': "rgba(255,255,255,.027)"
        });
    });
});