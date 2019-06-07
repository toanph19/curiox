$(document).ready(function () {
    //handle add answer
    $(document).on('click', '#btnSubmit', function () {
        if (localStorage.getItem("token") !== "" && localStorage.getItem("token") !== null) {
            let questionId = $(".question-content-text").attr('question-id');
            let content = $("#contentAnswer").val();
            var jsonObj = {
                "Token": localStorage.getItem('token'),
                "Content": content,
                "QuestionId": questionId,
            };
            debugger
            $.ajax({
                method: "POST",
                url: Curiox.Config.loginUrl + "/Api/Answer",
                contentType: "application/json",
                data: JSON.stringify(jsonObj),
                success: function (data, txtStatus, xhr) {
                    debugger
                    if (txtStatus === "success") {
                        CommonJS.showSuccessMsg("Add answer successfully!");
                    }
                },
                error: function () {
                    debugger
                    debugger
                    CommonJS.showFailMsg("An error occured! Please try again!");
                }
            });
        } else {
            //verify if already logged in
            debugger
            CommonJS.showFailMsg('You must logged in first!');
            window.location.href = '/Home/Login';
        }
    });

    //handle event click btn-upvote
    $('.btn-upvote').on('click', function () {
        if (localStorage.getItem("token") !== "" && localStorage.getItem("token") !== null) {
            let answerId = $(this).parents('.page-header').find('.anwser-content').attr('answer-id');
            var jsonObj = {
                "token": localStorage.getItem('token'),
            };
            let thisUpvote = $(this).find('.nbUpvote');
            $.ajax({
                method: "POST",
                url: Curiox.Config.loginUrl + "/Api/Answer/Upvote?answerId=" + answerId,
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
        } else {
            //verify if already logged in
            CommonJS.showFailMsg('You must logged in first!');
            window.location.href = '/Home/Login';
        }
        
    });
});