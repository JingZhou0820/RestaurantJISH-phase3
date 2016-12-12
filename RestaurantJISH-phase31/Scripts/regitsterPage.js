$(document).ready(function (event) {
    $('select').on('mouseenter', 'option', function (e) {
        $(this).css({ "background-color": "red", "color": "white" });
    });

    $('select').on('mouseout', 'option', function (e) {
        $(this).css({ "background-color": "white", "color": "black" });
    });

});