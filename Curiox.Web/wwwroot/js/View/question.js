$(document).ready(function () {
    //handle add answer
    $(document).on('click', '#btnSubmit', function () {
        if (localStorage.getItem("token") !== "" && localStorage.getItem("token") !== null) {
            let questionId = window.location.pathname.slice(-2);
            let content = $("#contentAnswer").val();
            var jsonObj = {
                "token": localStorage.getItem('token'),
                "content": content,
                "question_id": questionId
            };
            $.ajax({
                method: "POST",
                url: Curiox.Config.loginUrl + "/Api/Answer",
                contentType: "application/json",
                data: JSON.stringify(jsonObj),
                success: function (data, txtStatus, xhr) {
                    if (txtStatus === "success") {
                        CommonJS.showSuccessMsg("Add answer successfully!");
                    }
                    window.location.href = '/Home/Question/' + questionId;
                },
                error: function () {
                    CommonJS.showFailMsg("An error occured! Please try again!");
                    window.location.href = '/Home/Question/' + questionId;
                }
            });
        } else {
            //verify if already logged in
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
            debugger
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