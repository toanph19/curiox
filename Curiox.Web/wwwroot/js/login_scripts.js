const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
const container = document.getElementById('container');

signUpButton.addEventListener('click', () => {
    container.classList.add('right-panel-active');
});

signInButton.addEventListener('click', () => {
    container.classList.remove('right-panel-active');
});

$(document).ready(function () {
    $('#btnLogin').on('click', function () {
        var jsonObj = {
            "email": $('#txtEmail').val(),
            "password": $('#txtPassword').val()
        };
        
        $.ajax({
            method: "GET",
            url: Curiox.Config.loginUrl + "Api/Login",
            contentType: "application/json",
            data: JSON.stringify(jsonObj),
            success: function (data, txtStatus, xhr) {
                if (txtStatus === "success") {
                    debugger
                    localStorage.setItem("token", data.token);
                }
                CommonJS.showSuccessMsg("Login successfully!");
                window.location.href = "/";
            },
            error: function () {
                CommonJS.showFailMsg("An error occured! Please try again!");
            }
        });
    });

    //Check Enter key is pressed
    $('#formLogin').keypress(function (e) {
        if (e.which == 13 || e.keyCode == 13)  // the enter key code
        {
            $('#btnLogin').click();
            return false;
        }
    });

    $('#btnSignUp').on('click', function () {
        var jsonObj = {
            "username": $('#signupUserName').val(),
            "email": $('#signupEmail').val(),
            "password": $('#signupPassword').val()
        };
        $.ajax({
            method: "POST",
            url: MISA.Config.loginUrl + "/Api/SignUp",
            contentType: "application/json",
            data: JSON.stringify(jsonObj),
            success: function (data, txtStatus, xhr) {
                CommonJS.showSuccessMsg("Sign up successfully!");
                window.location.href = "/";
            },
            error: function () {
                commonJS.showFailMsg("An error occured! Please try again!");
            }
        });
    });

    $('#formSignUp').keypress(function (e) {
        if (e.which == 13 || e.keyCode == 13)  // the enter key code
        {
            $('#btnSignUp').click();
            return false;
        }
    });
});


