$(document).ready(function () {
    $('.flex-item').hover(
        function () {
            $(this).find('.purchase-button').fadeIn();
        },
        function () {
            $(this).find('.purchase-button').fadeOut();
        }
    );
});
