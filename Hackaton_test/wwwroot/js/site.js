// Sidebar

$(".option").hover(function () {
    $(this).css('cursor', 'pointer');
});

$(".active").hover(function () {
    $(this).css('background-color', '#161E2E');
});

$('.option').click(function (e) {
    $('.option').removeClass('active');

    var $this = $(this);
    if (!$this.hadClass('active')) {
        $this.addClass('active');
    }
});