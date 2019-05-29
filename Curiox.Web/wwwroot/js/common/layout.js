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
                    + '<li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#"><span class="glyphicon glyphicon-user"></span>' + '  '
                    + username
                    +    '<span class="caret"></span></a>'
                    +'<ul style="cursor: pointer;" class="dropdown-menu">'
                    +   '<li ><a id="btnLogout">Logout</a></li>'
                    +' </ul>'
                    +'</li >'
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

    $(document).on('click', '#btnAddQuestion', function () {
        if (localStorage.getItem("token") !== "" && localStorage.getItem("token") !== null) {
            $('#question-box').dialog('open');
        } else {
            //verify if already logged in
            CommonJS.showFailMsg('You must logged in first!');
            window.location.href = '/Home/Login';
        }
    });

    $(document).on('click', '#btnLogout', function () {
        localStorage.setItem("token", "");
        localStorage.setItem("user", "");
        window.location.href = "/";
    });
});