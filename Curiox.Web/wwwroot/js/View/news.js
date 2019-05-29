$(document).ready(function () {
    //handle event click btn-answer
    $('.btn-answer').on('click', function () {
        window.location.href = "/Home/Question";
    });

    //handle event click btn-upvote
    $('.btn-upvote').on('click', function () {
        let questionId = $(this).parents('.news-main-item').find('.question-title').attr('question-id');
        var jsonObj = {
            "token": localStorage.getItem('token'),
        };
        let thisUpvote = $(this).find('.nbUpvote');
        $.ajax({
            method: "POST",
            url: Curiox.Config.loginUrl + "/Api/Question/Upvote?questionId=" + questionId,
            contentType: "application/json",
            data: JSON.stringify(jsonObj),
            success: function (data, txtStatus, xhr) {
                if (txtStatus === "success") {
                    let nbUpvote = parseInt(thisUpvote.html());
                    thisUpvote.html(++nbUpvote);
                }
            },
            error: function () {
                CommonJS.showFailMsg("An error occured! Please try again!");
            }
        });
    });

    //handle event click btn-downvote
    $('.btn-downvote').on('click', function () {
        alert('downvote');
    });
});