$(document).ready( function() {
    $.ajax({
        type: "GET",
        url: "api/vehicles",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response);
        },
        error: function () {
            console.log(response);
        }
    });

    $.ajax({
        type: 'POST',
        url: 'api/vehicles',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data), // access in body
    }).done(function () {
        console.log('SUCCESS');
    }).fail(function (msg) {
        console.log('FAIL');
    }).always(function (msg) {
        console.log('ALWAYS');
    });
});