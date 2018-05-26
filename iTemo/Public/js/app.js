$(document).ajaxStart(function (evt, xhr, request, settings) {
    NProgress.start();
});


$(document).ajaxStop(function () {
    NProgress.done();
});

$(document).ajaxError(function (event, xhr, options, exc) {
    if (xhr.status === 401) {
        //location.reload();
    }
});