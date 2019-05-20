$(document).ready(function () {
    //check if already logged in
    //if logged in
    if (localStorage.getItem("token") !== "" && localStorage.getItem("token") !== null) {
        let token = localStorage.getItem("token");
        $.ajax({
            method: "GET",
            url: Curiox.Config.loginUrl + "/User/GetUser?token=" + token,
            success: function (data, status, xhr) {
                let username = data.username;
                let html = ''
                    + '<li><a href="#"><span class="glyphicon glyphicon-user"></span>' +  '  ' + username  + '</a></li>'
                    + '<button id="btnAddQuestion" class="btn btn-danger navbar-btn">Add Question</button>'
                    + '';
                $('#user-box').html(html);
            },
            error: function (err, stt, xhr) {
                window.location.href = "/";
            }
        });
    } else {
        let html = ''
            + '<li><a href="/Home/Login"><span class="glyphicon glyphicon-user"></span> Sign Up</a></li>'
            + '<li><a href="/Home/Login"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>'
            + '<button id="btnAddQuestion" class="btn btn-danger navbar-btn">Add Question</button>'
            + '';
        $('#user-box').html(html);
    }

    $('#btnAddQuestion').on('click', function () {
        if (localStorage.getItem("token") !== "" && localStorage.getItem("token") !== null) {
            $('#question-box').dialog('open');
        } else {
            //verify if already logged in
            CommonJS.showFailMsg('You must logged in first!');
            window.location.href = '/Home/Login';
        }
    });
});