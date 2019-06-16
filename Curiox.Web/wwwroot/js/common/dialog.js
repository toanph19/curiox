$('#question-box').dialog({
    autoOpen: false,
    title: "Add Question",
    modal: true,
    resizable: false,
    width: 620,
    height: 400,
    beforeClose: function (event) {
        $('.form-control').val('');
    },
    buttons: [
        {
            text: "Add Question",
            id: 'btnSubmitQuestion',
            class: 'btn btn-primary',
            click: function () {
                let category = $('#selectCategory').val();
                if (category === 'Select category') {
                    category = 'General';
                }
                var jsonObj = {
                    "category": category,
                    "title": $('#question-title').val(),
                    "content": $('#question-content').val(),
                    "token": localStorage.getItem('token')
                };
                $.ajax({
                    method: "POST",
                    url: Curiox.Config.loginUrl + '/Api/Question',
                    data: JSON.stringify(jsonObj),
                    contentType: "application/json",
                    success: function (data, status, xhr) {
                        CommonJS.showSuccessMsg('Success!');
                        $('#question-box').dialog('close');
                        location.reload();
                    },
                    error: function (err, stt, xhr) {
                        CommonJS.showFailMsg('An error occured! Please try again!');
                        $('#question-box').dialog('close');
                        location.reload();
                    }
                });
            }
        },
        {
            text: "Cancel",
            id: 'btnCancel',
            class: 'btn',
            click: function () {
                $(this).dialog("close");
            }
        }
    ]
});


$('#confirm-box').dialog({
    autoOpen: false,
    title: "Confirm delete answer",
    modal: true,
    resizable: false,
    width: 350,
    height: 170,
    buttons: [
        {
            text: "Delete Answer",
            id: 'btnDeleteAnswer',
            class: 'btn btn-primary',
            click: function () {
                let idAnswer = $('#confirm-box').data('id');
                var jsonObj = {
                    "token": localStorage.getItem('token'),
                };
                $.ajax({
                    method: "DELETE ",
                    url: Curiox.Config.loginUrl + '/Api/Answer?answerId=' + idAnswer,
                    data: JSON.stringify(jsonObj),
                    contentType: "application/json",
                    success: function (data, status, xhr) {
                        CommonJS.showSuccessMsg('Success!');
                        $('#confirm-box').dialog('close');
                        location.reload();
                    },
                    error: function (err, stt, xhr) {
                        CommonJS.showFailMsg('An error occured! Please try again!');
                        $('#question-box').dialog('close');
                        location.reload();
                    }
                });
            }
        },
        {
            text: "Cancel",
            id: 'btnCancel',
            class: 'btn',
            click: function () {
                $(this).dialog("close");
            }
        }
    ]
});