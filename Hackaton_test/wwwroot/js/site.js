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