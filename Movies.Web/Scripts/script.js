
var tags = null;
$("#tags").keyup(function () {
    clearTimeout(tags);
    tags = setTimeout(function () {
        if ($("#tags").val().length < 3) {
            $("#status").text("");
            $("#loadsource").text("");
            return false;
        }

        var tags = $("#tags").val();
        var container = $("#movies");
        var token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: "/Home/GetMovies",
            type: "POST",
            async: true,
            dataType: "html",
            data: { tags: tags, __RequestVerificationToken: token },
            success: function (data) {
                $("#status").text("Success.");
                container.html(data);

                //$("img").fadeTo(1000, 1);
            },
            beforeSend: function() {
                $("#status").text("Retrieving ...");
            },
            complete: function() {
                $("#status").text("");
            },
            error: function() {
                $("#status").text("Error.");
            }
        });
        

    }, 500);
})

$('#MovieDetailsModel').on('hidden.bs.modal', function() {
    // do something…
    $("#MovieDetailsData").html("<div id='MovieDetailsData' class='modal-body'>" +
        "<div style='text-align: center'>" +
        "<img src='../../Content/Images/ajax-loader.gif'/>" +
        "</div></div>");
});

function loadMovieDetails(title, id) {
    var tag = $("#tags").val();
    $('#MovieDetailsModel').modal('show');
    $("#myModalLabel").text(title);

    var token = $('input[name="__RequestVerificationToken"]').val();

    $.ajax({
        url: '/Home/GetMovie',
        type: "POST",
        async: true,
        dataType: "html",
        data: { tags: tag, id: id, __RequestVerificationToken: token },
        success: function (data) {
            $("#MovieDetailsData").html(data);
        },
        error: function () {
            $("#MovieDetailsData").html("Error occured, please try again later.");
        }
    });
}