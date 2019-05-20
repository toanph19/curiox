$(document).ready(function () {
    //handle event click btn-answer
    $('.btn-answer').on('click', function () {
        window.location.href = "/Home/Question";
        //if (localStorage.getItem("token") !== "" && localStorage.getItem("token") !== null) {
        //    let token = localStorage.getItem("token");
        //    $.ajax({
        //        method: "GET",
        //        url: Curiox.Config.loginUrl,
        //        success: function (data, status, xhr) {
                    
        //        },
        //        error: function (err, stt, xhr) {
        //            console.log(err);
        //            CommonJS.showFailMsg('Something went wrong!');
        //        }
        //    });
        //} else {
        //    window.location.href = "/Home/Login";
        //}
    });

    //handle event click btn-upvote
    $('.btn-upvote').on('click', function () {
        alert('upvote');
    });

    //handle event click btn-downvote
    $('.btn-downvote').on('click', function () {
        alert('downvote');
    });
});